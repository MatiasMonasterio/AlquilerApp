using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AlquilerApp.Models;
using System.Linq;
using System;

namespace AlquilerApp.Controllers
{
    public class RenterController: Controller
    {
        /*============================================================================================================*/
        /*======================================== ATRIBUTOS Y CONSTRUCTOR ===========================================*/
        /*============================================================================================================*/
        private readonly AppDbContext db;
        public RenterController( AppDbContext context )
        { this.db = context; }


        /*============================================================================================================*/
        /*====================================== RUTAS PRINCIPALES ====================================================*/
        /*============================================================================================================*/
        public IActionResult Login(){ return View(); }
        public IActionResult SetPassword() { return View(); }
        public IActionResult Department(){
            Renter RenterSession = HttpContext.Session.Get<Renter>("RenterSession");
            Contract Contract = db.Contract.Where( c => c.RenterId == RenterSession.Id ).First();
            List<Fee> FeesPaid = db.Fee.Where( f => f.ContractId == Contract.Id && f.PaymentDate != new DateTime( 0001, 01, 01 ) ).ToList();
            List<Fee> FeesPending = db.Fee.Where( f => f.ContractId == Contract.Id && f.PaymentDate == new DateTime( 0001, 01, 01 ) ).ToList();


            this.ViewBag.FeesPaid = FeesPaid;
            this.ViewBag.FeesPending = FeesPending;
            return View();
        }
        public IActionResult Account()
        {
            Renter RenterSession = HttpContext.Session.Get<Renter>("RenterSession");
            Contract ContractInfo = db.Contract.Where( c => c.RenterId == RenterSession.Id ).First();
            Department Department = db.Department.Where( d => d.Id == ContractInfo.DepartmentId ).First();

            this.ViewBag.User = RenterSession;
            this.ViewBag.Contract = ContractInfo;
            this.ViewBag.Department = Department;

            return View();
        }
        public IActionResult Settings(){
            Renter RenterSession = HttpContext.Session.Get<Renter>("RenterSession");

            this.ViewBag.User = RenterSession;
            return View();
        }


        /*============================================================================================================*/
        /*====================================== RUTAS SECUNDARIAS ====================================================*/
        /*============================================================================================================*/

        public IActionResult UserInfo(){ return View(); }
        public IActionResult UpdateUserInfo(){
            Renter RenterSession = HttpContext.Session.Get<Renter>("RenterSession");

            this.ViewBag.User = RenterSession;
            return View();
        }
        public IActionResult UpdatePassword(){ return View(); }


        /*============================================================================================================*/
        /*====================================== ACCIONES Y REDIRECCIONES =============================================*/
        /*============================================================================================================*/
        public IActionResult Logout(){ return RedirectToAction("Login"); }
        [HttpPost]
        public IActionResult CheckLogin( string email, string password )
        {
            Renter renterCheck = db.Renter.Where( renter => renter.Email == email ).FirstOrDefault();

            if( renterCheck != null )
            {
                if(  renterCheck.Password == password )
                {
                    if( renterCheck.Active == true ) { 
                        HttpContext.Session.Set<Renter>("RenterSession", renterCheck );
                        return RedirectToAction("Department");
                    }
                    else { return RedirectToAction("SetPassword"); }
                }
                else { return RedirectToAction("Login"); }
            }
            else { return RedirectToAction("Login"); }
        }
        [HttpPost]
        public IActionResult createPassword( string Email, string password, string PasswordRepeat )
        {
            Renter renter = db.Renter.Where( r => r.Email == Email ).FirstOrDefault();

            if( renter != null || renter.Active == true )
            {
                if( password == PasswordRepeat )
                {
                    renter.Password = password;
                    renter.Active = true;

                    db.SaveChanges();

                    Renter renterSession = db.Renter.Where( r => r.Email == Email ).First();
                    HttpContext.Session.Set<Renter>("RenterSession", renterSession );

                    return RedirectToAction("Department");
                }
                else { return RedirectToAction("SetPassword"); }
            }
            else { return RedirectToAction("SetPassword"); }
        }
        [HttpPost]
        public IActionResult SaveUserInfo(string name, string lastname, string email, string telephone)
        {
            Renter RenterSession = HttpContext.Session.Get<Renter>("RenterSession");
            Renter User = db.Renter.Where( r => r.Id == RenterSession.Id ).First();

            User.Name = name;
            User.Lastname = lastname;
            User.Email = email;
            User.Telephone = telephone;

            db.SaveChanges();
            return RedirectToAction("Account");
        }
        [HttpPost]
        public IActionResult SaveNewPassword(string Password, string NewPassword, string NewPasswordRepeat)
        {
            Renter RenterSession = HttpContext.Session.Get<Renter>("RenterSession");
            Renter UpdateUserPassWord = db.Renter.Where( r => r.Id == RenterSession.Id ).First();

            if( UpdateUserPassWord.Password == Password && NewPassword == NewPasswordRepeat )
            {
                UpdateUserPassWord.Password = NewPassword;
                db.SaveChanges();
                return RedirectToAction("Account");
            }
            else { return RedirectToAction("UpdatePassword"); }
        }
    }
}
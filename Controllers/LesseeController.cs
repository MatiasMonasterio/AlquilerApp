using Microsoft.AspNetCore.Mvc;
using AlquilerApp.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace AlquilerApp.Controllers
{
    public class LesseeController : Controller
    {
        /*============================================================================================================*/
        /*======================================== ATRIBUTOS Y CONSTRUCTOR ===========================================*/
        /*============================================================================================================*/
        private readonly AppDbContext db;
        public LesseeController( AppDbContext context ) { this.db = context; }


        /*============================================================================================================*/
        /*====================================== RUTAS PRINCIPALES ====================================================*/
        /*============================================================================================================*/
        public IActionResult Login() { return View(); }
        public IActionResult Register() { return View(); }


        public IActionResult Dashboard()
        {
            Lessee user = HttpContext.Session.Get<Lessee>("LesseeSession");

            List<Department> Departments = db.Department.Where( dep => dep.LesseeId == user.Id ).ToList();
            ViewBag.DepartmentsList = Departments;

            return View();
        }


        [HttpGet]
        public IActionResult Department( int id )
        {
            Lessee user = HttpContext.Session.Get<Lessee>("LesseeSession");
            Department department = db.Department.Where( department => department.Id == id ).First(); // Buscar porque no me funciona el metodo FIND
            Contract contract = db.Contract.Where( contract => contract.DepartmentId == id ).FirstOrDefault();

            if( contract != null )
            {
                List<Fee> feePay = db.Fee.Where( fee => fee.ContractId == contract.Id && fee.PaymentDate != new DateTime( 0001, 01, 01 ) ).ToList();
                List<Fee> fee = db.Fee.Where( fee => fee.ContractId == contract.Id && fee.PaymentDate == new DateTime( 0001, 01, 01 ) ).ToList();

                this.ViewBag.Fee = fee;
                this.ViewBag.FeePay = feePay;
                this.ViewBag.Contract = contract;
            }
            
            this.ViewBag.Department = department;
            return View();
        }


        public IActionResult Account()
        {
            Lessee user = HttpContext.Session.Get<Lessee>("LesseeSession");
            Lessee userInfo = db.Lessee.Where( lessee => lessee.Email == user.Email ).FirstOrDefault();
            List<Department> departmentList = db.Department.Where( dep => dep.LesseeId == userInfo.Id ).ToList();

            this.ViewBag.UserInfo = userInfo;
            this.ViewBag.Departments = departmentList;

            return View();
        }


        public IActionResult Settings()
        {
            Lessee user = HttpContext.Session.Get<Lessee>("LesseeSession");
            Lessee userInfo = db.Lessee.Where( lessee => lessee.Email == user.Email ).FirstOrDefault();

            this.ViewBag.UserInfo = userInfo;
            return View();
        }


        /*============================================================================================================*/
        /*====================================== RUTAS SECUNDARIAS ====================================================*/
        /*============================================================================================================*/
        public IActionResult AddDepartment() { return View(); }

        [HttpGet]
        public IActionResult AddRenter( int id )
        {
            this.ViewBag.DepartmentId = id;
            return View(); 
        }

        [HttpGet]
        public IActionResult UpdateDepartment( int id )
        {
            Department department = db.Department.Where( dep => dep.Id == id ).First();
            ViewBag.Department = department;
            return View(); 
        }


        public IActionResult UpdateUserInfo()
        {
            Lessee User = HttpContext.Session.Get<Lessee>("LesseeSession");

            this.ViewBag.UserInfo = User;
            return View();
        }

        public IActionResult UpdatePassword(){ return View(); }
        public IActionResult UpdateContract() { return View(); }


        /*============================================================================================================*/
        /*====================================== ACCIONES Y REDIRECCIONES =============================================*/
        /*============================================================================================================*/
        
        public IActionResult Logout() { return RedirectToAction("Login"); }


        [HttpPost]
        public IActionResult SignIn( string email, string password )
        {
            var lessee = db.Lessee.Where(l => l.Email == email ).FirstOrDefault();

            if( lessee != null  )
            {
                if( lessee.Email == email && lessee.Password == password ){
                    HttpContext.Session.Set<Lessee>("LesseeSession", lessee );
                    return RedirectToAction("Dashboard");
                }
                else return RedirectToAction("Login");
            }
            else return RedirectToAction("Login");
        }


        [HttpPost]
        public IActionResult CrearAccount( string name, string lastname, string email, string password, string passwordRepeat )
        {
            var LesseeExist = db.Lessee.Where( l => l.Email == email).FirstOrDefault();

            if( password == passwordRepeat && LesseeExist == null )
            {
                Lessee newLessee = new Lessee(){
                    Name = name,
                    Lastname = lastname,
                    Email = email,
                    Password = password,
                    Theme = true,
                    FeeEmitAlert = false,
                    FeeOverdueAlert = true,
                    PaymentTicket = true
                };

                db.Lessee.Add( newLessee );
                db.SaveChanges();

                HttpContext.Session.Set<Lessee>("LesseeSession", newLessee );
                return RedirectToAction("Dashboard");
            }
            else return RedirectToAction("Register");
        }


        [HttpPost]
        public IActionResult CreateNewDepartment(
            string address, int number, string town, string provincia, int age, string description)
        {
            Lessee user = HttpContext.Session.Get<Lessee>("LesseeSession");

            Department newDepartment = new Department(){
                Address = address,
                Number = number,
                Town = town,
                provincia = provincia,
                age = age,
                state = false,
                description = description,
                LesseeId = user.Id
            };

            db.Department.Add(newDepartment);
            db.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult createNewRenter(
            int departmentId, string name, string lastname, string email, string telephone,
            DateTime dateStart, DateTime dateEnd, int amount )
        {
            Renter RenterExist = db.Renter.Where( renter => renter.Email == email ).FirstOrDefault();

            if( RenterExist == null )
            {
                Renter NewRenter = new Renter(){
                    Name = name,
                    Lastname = lastname,
                    Email = email,
                    Telephone = telephone,
                    Password = "12345678"
                };

                db.Renter.Add( NewRenter );
                db.SaveChanges();
                Renter getNewRenter = db.Renter.Where( renter => renter.Email == NewRenter.Email ).First();

                Contract NewContract = new Contract(){
                    DepartmentId = departmentId,
                    RenterId = getNewRenter.Id,
                    InitialDate = dateStart,
                    finishDate = dateEnd,
                    amount = amount
                };

                db.Contract.Add( NewContract );
                db.SaveChanges();
                Contract getContract = db.Contract.Where( contract => contract.RenterId == getNewRenter.Id && contract.DepartmentId == departmentId ).First();


                double amountMonth = amount;
                for(var i = 1; i <= 24; i++ )
                {
                    if( i != 1 ) { amountMonth = amountMonth * ( 1.15 ); }
                    Fee NewFee = new Fee(){
                        Id = i,
                        ContractId = getContract.Id,
                        Amount = amountMonth,
                        EmitDate = dateStart.AddMonths( i - 1 ),
                        ExpiryDate = dateStart.AddMonths( i - 1 ).AddDays( 9 )
                    };

                    db.Fee.Add( NewFee );
                    db.SaveChanges();
                }

                Department department = db.Department.Where( dep => dep.Id == departmentId ).First();
                department.state = true;

                return RedirectToAction("Department", new{id = departmentId});
            }
            else return RedirectToAction("AddRenter", new{id = departmentId} );
        }

        [HttpPost]
        public IActionResult SaveDepartmentInfo( int departmentId,
            string address, int number, string town, string provincia, int age, string description )
        {
            Department updateDepartment = db.Department.Where( dep => dep.Id == departmentId ).First();

            updateDepartment.Address = address;
            updateDepartment.Number = number;
            updateDepartment.Town = town;
            updateDepartment.provincia = provincia;
            updateDepartment.age = age;
            updateDepartment.description = description;

            db.SaveChanges();
            return RedirectToAction("Department", new{ id = departmentId });
        }


        [HttpGet]
        public IActionResult ResetPassword( int Renter )
        {
            Renter ResetPasswordRenter = db.Renter.Where( renter => renter.Id == Renter ).First();
            Contract ContractToRedirect = db.Contract.Where( cont => cont.RenterId == Renter ).First();

            ResetPasswordRenter.Password = "11111111";
            db.SaveChanges();

            return RedirectToAction("Department", new{id = ContractToRedirect.DepartmentId });
        }


        [HttpGet]
        public IActionResult DeleteRenter( int Renter )
        {
            Contract ContractDelete = db.Contract.Where( contract => contract.RenterId == Renter ).First();
            List<Fee> FeeList = db.Fee.Where( fee => fee.ContractId ==  ContractDelete.Id ).ToList();
            Renter RenterDelete = db.Renter.Where( renter => renter.Id == Renter ).First();

            FeeList.ForEach( fee => db.Fee.Remove( fee ) );
            db.Contract.Remove( ContractDelete );
            db.Renter.Remove( RenterDelete );

            Department department = db.Department.Where( dep => dep.Id == ContractDelete.DepartmentId ).First();
            department.state = false;

            db.SaveChanges();
            return RedirectToAction("Department", new{id = ContractDelete.DepartmentId });
        }


        [HttpGet]
        public IActionResult confirmPayment( int fee, int contract )
        {
            Fee feePayment = db.Fee.Where( f => f.Id == fee && f.ContractId == contract ).First();
            feePayment.PaymentDate = DateTime.Now;

            db.SaveChanges();
            return RedirectToAction("Department", new{id = 2});
        }


        
        [HttpPost]
        public IActionResult SaveUserInfo( string name, string lastname, string email, string telephone )
        {
            Lessee User = HttpContext.Session.Get<Lessee>("LesseeSession");

            var UserToUpdate = db.Lessee.Find( User.Id );
            UserToUpdate.Name = name;
            UserToUpdate.Lastname = lastname;
            UserToUpdate.Email = email;
            UserToUpdate.Telephone = telephone;

            db.SaveChanges();

            HttpContext.Session.Set<Lessee>( "LesseeSession", UserToUpdate );
            return RedirectToAction("Account");
        }


        [HttpPost]
        public IActionResult SaveNewPassword(string password, string newPassword, string newPasswordRepeat)
        {
            Lessee User = HttpContext.Session.Get<Lessee>("LesseeSession");

            if( password == User.Password || newPassword == newPasswordRepeat )
            {
                var UserUpdate = db.Lessee.Find( User.Id );
                UserUpdate.Password = newPassword;
                db.SaveChanges();

                return RedirectToAction("Account");
            }
            else return RedirectToAction("UpdatePassword");

        }


        [HttpPost]
        public IActionResult saveContractInfo()
        {
            return RedirectToAction("Account");
        }

    }
}
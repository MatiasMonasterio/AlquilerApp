using Microsoft.AspNetCore.Mvc;
using System;

namespace AlquilerApp.Controllers
{
    public class LesseeController : Controller
    {
        public LesseeController()
        { }

        // PATH
        public IActionResult index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        // [Route("Lessee/Account-Info")]
        // public IActionResult RedirectRegisterAccountInfo(){
        //     return RedirectToAction("RegisterAccountInfo");
        // }

        [Route("Lessee/Register/Account-Info")]
        public IActionResult RegisterAccountInfo()
        {
            return View();
        }


        // [Route("Lessee/Departments-Info")]
        // public IActionResult RedirectRegisterDepartmentsInfo(){
        //     return RedirectToAction("RegisterDepartmentsInfo");
        // }

        [Route("Lessee/Register/Departments-Info")]
        public IActionResult RegisterDepartmentsInfo()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Department( string idDeparment )
        {
            // this.ViewBag.idDeparment = idDeparment;
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }

        public IActionResult UpdateUserInfo()
        {
            return View();
        }

        public IActionResult UpdatePassword()
        {
            return View();
        }
        
        public IActionResult UpdateContract()
        {
            return View();
        }

        public IActionResult SaveNewPassword()
        {
            return RedirectToAction("Account");
        }

        public IActionResult SaveUserInfo()
        {
            return RedirectToAction("Account");
        }

        public IActionResult saveContractInfo()
        {
            return RedirectToAction("Account");
        }

        public IActionResult AddRenter()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult createNewRenter(
            string name, string lastname, string email, string telephone,
            string dateStart, string dateEnd, string amount
        ){
            if( email != "" )
            {
                Console.WriteLine($"El nombre es: {name}");
            }
            
            return RedirectToAction("Department", new{id = 2});
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace AlquilerApp.Controllers
{
    public class LesseeController : Controller
    {
        public LesseeController()
        { }
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
    }
}
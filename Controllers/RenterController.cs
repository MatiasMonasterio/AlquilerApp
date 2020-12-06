using Microsoft.AspNetCore.Mvc;

namespace AlquilerApp.Controllers
{
    public class RenterController: Controller
    {
        public RenterController()
        { }

        public IActionResult Index(){
            return View();
        }

        public IActionResult Login(){
            return View();
        }

        public IActionResult SetPassword(){
            return View();
        }

        public IActionResult CheckLogin( string email, string password )
        {
            return RedirectToAction("SetPassword");
        }

        public IActionResult Department(){
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult Settings(){
            return View();
        }

        public IActionResult Logout(){
            return RedirectToAction("Login");
        }

        public IActionResult UserInfo(){
            return View();
        }

        public IActionResult UpdateUserInfo(){
            return View();
        }

        public IActionResult UpdatePassword(){
            return View();
        }

        public IActionResult SaveUserInfo(string name, string lastname, string email, string telephone)
        {
            return RedirectToAction("Account");
        }

        public IActionResult SaveNewPassword(string password, string newPassword, string newPasswordRepeat)
        {
            return RedirectToAction("Account");
        }
    }
}
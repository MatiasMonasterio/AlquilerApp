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
    }
}
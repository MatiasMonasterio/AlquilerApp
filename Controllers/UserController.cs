using Microsoft.AspNetCore.Mvc;

namespace AlquilerApp.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        { }
        public IActionResult index()
        {
            return View();
        }
    }
}
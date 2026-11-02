using Microsoft.AspNetCore.Mvc;
using MVC_Application.Models;

namespace MVC_Application.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register register)
        {
            return View(register);
        }
    }
}

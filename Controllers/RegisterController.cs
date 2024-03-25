using Store.Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Store.Management.Controllers
{
    public class RegisterController : Controller
    {

        public RegisterController()
        {
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
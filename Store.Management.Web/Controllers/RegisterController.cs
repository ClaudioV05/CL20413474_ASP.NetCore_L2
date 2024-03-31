using Microsoft.AspNetCore.Mvc;

namespace Store.Management.Web.Controllers
{
    public class RegisterController : Controller
    {
        public RegisterController()
        {

        }

        [ActionName("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [ActionName("fj.")]
        public IActionResult Registerr()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace Store.Management.Web.Controllers
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
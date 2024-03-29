using Microsoft.AspNetCore.Mvc;
using Store.Management.Web.Models;

namespace Store.Management.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() { }

        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("~/Views/Shared/_Error.cshtml", new StoreManagementErrorViewModel() { Message = "The page don't was show." });
            }
        }
    }
}
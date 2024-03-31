using Microsoft.AspNetCore.Mvc;
using Store.Management.Application.Interfaces;
using Store.Management.Web.Models;
using Store.Management.Web.ViewModels;

namespace Store.Management.Web.Controllers
{
    /// <summary>
    /// HomeController.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IServiceLinks _serviceLinks;

        /// <summary>
        /// HomeController.
        /// </summary>
        /// <param name="serviceLinks"></param>
        public HomeController(IServiceLinks serviceLinks)
        {
            _serviceLinks = serviceLinks;
        }

        [HttpGet()]
        [ActionName("Index")]
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

        [HttpPost()]
        [ActionName("StoreManagementLoginUser")]
        public IActionResult StoreManagementLoginUser([FromBody] StoreManagementLoginUserViewModel storeManagementLoginUserViewModel)
        {
            try
            {
               // var user = _serviceLinks.LoginUser($"{_serviceLinks.ReturnStoreManagementUriApi()}{_serviceLinks.ReturnStoreManagementNameController()}{_serviceLinks.ReturnStoreManagementActionNameLoginUser()}", new User() { UserID = 1, Name = "Jesus" });

                return View();
            }
            catch (Exception)
            {
                return View("~/Views/Shared/_Error.cshtml", new StoreManagementErrorViewModel() { Message = "The page don't was show." });
            }
        }
    }
}
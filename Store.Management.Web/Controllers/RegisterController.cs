using Microsoft.AspNetCore.Mvc;
using Store.Management.Application.Interfaces;
using Store.Management.Domain.Entities;
using Store.Management.Web.Models;
using Store.Management.Web.ViewModels;

namespace Store.Management.Web.Controllers;

public class RegisterController : Controller
{
    private readonly IServiceLinks _serviceLinks;

    /// <summary>
    /// RegisterController.
    /// </summary>
    /// <param name="serviceLinks"></param>
    public RegisterController(IServiceLinks serviceLinks)
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
    [ActionName("StoreManagementRegisterNewUser")]
    public IActionResult StoreManagementRegisterNewUser([FromBody] StoreManagementRegisterUser storeManagementRegisterUser)
    {
        try
        {
            _serviceLinks.RegisterUser($"{_serviceLinks.ReturnStoreManagementUriApi()}{_serviceLinks.ReturnStoreManagementNameController()}{_serviceLinks.ReturnStoreManagementActionNameRegistrationUser()}", new User()
            {
                Email = storeManagementRegisterUser.Email,
                Password = storeManagementRegisterUser.Password
            });

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        catch (Exception ex)
        {
            return View("~/Views/Shared/_Error.cshtml", new StoreManagementErrorViewModel() { Message = ex.Message });
        }
    }
}
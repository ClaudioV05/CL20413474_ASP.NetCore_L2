using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Management.Application.Interfaces;
using Store.Management.Web.Models;
using Store.Management.Web.ViewModels;

namespace Store.Management.Web.Controllers
{
    /// <summary>
    /// StoreManagementWebController.
    /// </summary>
    public class StoreManagementController : Controller
    {
        private readonly IServiceLinks _serviceLinks;

        /// <summary>
        /// StoreManagementWebController.
        /// </summary>
        /// <param name="serviceLinks"></param>
        public StoreManagementController(IServiceLinks serviceLinks)
        {
            _serviceLinks = serviceLinks;
        }

        [HttpGet()]
        [ActionName("Index")]
        public IActionResult Index()
        {
            StoreManagementViewModel storeManagementViewModel = new StoreManagementViewModel();

            try
            {
                this.InitializeViewStoreManagement(ref storeManagementViewModel);
                return View("~/Views/StoreManagement/Index.cshtml", storeManagementViewModel);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/_Error.cshtml", new StoreManagementErrorViewModel() { Message = "The page don't was show." });
            }
        }

        [HttpGet()]
        [ActionName("GetTheListOfSubCategoryByCategoryId")]
        public JsonResult GetTheListOfSubCategoryByCategoryId(int id)
        {
            var lstSubCategory = _serviceLinks.GetTheListOfSubCategoryByCategoryId($"{_serviceLinks.ReturnStoreManagementUriApi()}{_serviceLinks.ReturnStoreManagementNameController()}{_serviceLinks.ReturnStoreManagementActionNameGetTheListOfSubCategoryByCategoryId()}/{id}");
            return Json(lstSubCategory);
        }

        [HttpGet()]
        [ActionName("GetTheListOfProductBySubCategoryId")]
        public JsonResult GetTheListOfProductBySubCategoryId(int id)
        {
            var lstProducts = _serviceLinks.GetTheListOfProductBySubCategoryId($"{_serviceLinks.ReturnStoreManagementUriApi()}{_serviceLinks.ReturnStoreManagementNameController()}{_serviceLinks.ReturnStoreManagementActionNameGetTheListOfProductBySubCategoryId()}/{id}");
            return Json(lstProducts);
        }

        #region InitializeView

        /// <summary>
        /// Initialize the view index (StoreManagement).
        /// </summary>
        /// <param name="storeManagementViewModel"></param>
        private void InitializeViewStoreManagement(ref StoreManagementViewModel storeManagementViewModel)
        {
            var lstCategories = _serviceLinks.GetTheListOfCategories($"{_serviceLinks.ReturnStoreManagementUriApi()}{_serviceLinks.ReturnStoreManagementNameController()}{_serviceLinks.ReturnStoreManagementActionNameGetTheListOfCategories()}");

            if (storeManagementViewModel is not null)
            {
                // Initializer the list of Category.
                storeManagementViewModel?.ListCategories?.Add(new SelectListItem() { Value = Convert.ToString(0), Text = "Select", Selected = true });

                // Initializer the list of the SubCategory.
                storeManagementViewModel?.ListSubCategories?.Add(new SelectListItem() { Value = Convert.ToString(0), Text = "Select", Selected = true });

                // Initializer the list of the Product.
                storeManagementViewModel?.ListProducts?.Add(new SelectListItem() { Value = Convert.ToString(0), Text = "Select", Selected = true });

                if (lstCategories is not null && lstCategories.Any())
                {
                    for (int i = 0; i < lstCategories.Count; i++)
                    {
                        storeManagementViewModel?.ListCategories?.Add(new SelectListItem() { Value = Convert.ToString(lstCategories[i]?.CategoryID), Text = lstCategories[i]?.CategoryName?.ToString(), Selected = false });
                    }
                }
            }
        }

        #endregion InitializeView
    }
}
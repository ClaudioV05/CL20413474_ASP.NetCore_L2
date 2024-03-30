using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Management.Application.Interfaces;
using Store.Management.Web.Models;
using Store.Management.Web.ViewModels;

namespace Store.Management.Web.Controllers
{
    /// <summary>
    /// StoreManagementWebController
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

        [HttpGet]
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

        [HttpGet]
        public IActionResult SaveNewItemOfProduct()
        {
            StoreManagementViewModel storeManagementViewModel = new StoreManagementViewModel();

            try
            {
                this.InitializeViewStoreManagementNewItemProduct(ref storeManagementViewModel);
                return View("~/Views/StoreManagement/NewItemOfProduct.cshtml", storeManagementViewModel);
            }
            catch (Exception)
            {
                return View("~/Views/Shared/_Error.cshtml", new StoreManagementErrorViewModel() { Message = "The page don't was show." });
            }
        }

        [HttpGet]
        public JsonResult GetTheListOfSubCategoryByCategoryId(int id)
        {
            var lstSubCategory = _serviceLinks.GetTheListOfSubCategoryByCategoryId($"{_serviceLinks.ReturnStoreManagementUriApi()}{_serviceLinks.ReturnStoreManagementNameController()}{_serviceLinks.ReturnStoreManagementActionNameGetTheListOfSubCategoryByCategoryId()}/{id}");
            return Json(lstSubCategory);
        }

        [HttpGet]
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
            var lstCategory = _serviceLinks.GetTheListOfCategory($"{_serviceLinks.ReturnStoreManagementUriApi()}{_serviceLinks.ReturnStoreManagementNameController()}{_serviceLinks.ReturnStoreManagementActionNameGetTheListOfCategory()}");

            if (storeManagementViewModel is not null)
            {
                // Initializer the list of Category.
                storeManagementViewModel?.ListCategory?.Add(new SelectListItem() { Value = Convert.ToString(0), Text = "Select", Selected = true });

                // Initializer the list of the SubCategory.
                storeManagementViewModel?.ListSubCategory?.Add(new SelectListItem() { Value = Convert.ToString(0), Text = "Select", Selected = true });

                // Initializer the list of the Product.
                storeManagementViewModel?.ListProduct?.Add(new SelectListItem() { Value = Convert.ToString(0), Text = "Select", Selected = true });

                if (lstCategory is not null && lstCategory.Any())
                {
                    for (int i = 0; i < lstCategory.Count; i++)
                    {
                        storeManagementViewModel?.ListCategory?.Add(new SelectListItem() { Value = Convert.ToString(lstCategory[i]?.CategoryID), Text = lstCategory[i]?.CategoryName?.ToString(), Selected = false });
                    }
                }
            }
        }

        /// <summary>
        /// Initialize the view (StoreManagement) new item of product.
        /// </summary>
        /// <param name="storeManagementViewModel"></param>
        private void InitializeViewStoreManagementNewItemProduct(ref StoreManagementViewModel storeManagementViewModel)
        {
            var lstCategory = _serviceLinks.GetTheListOfCategory($"{_serviceLinks.ReturnStoreManagementUriApi()}{_serviceLinks.ReturnStoreManagementNameController()}{_serviceLinks.ReturnStoreManagementActionNameGetTheListOfCategory()}");

            if (storeManagementViewModel is not null)
            {
                storeManagementViewModel.InitializeView = false;
            }
        }

        #endregion InitializeView
    }
}
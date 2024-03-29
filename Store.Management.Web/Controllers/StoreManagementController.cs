using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Management.Application.Interfaces;
using Store.Management.Web.Models;

namespace Store.Management.Web.Controllers
{
    public class StoreManagementController : Controller
    {
        private readonly IServiceHttpClient _serviceHttpClient;

        public StoreManagementController(IServiceHttpClient serviceHttpClient)
        {
            _serviceHttpClient = serviceHttpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            DtoStoreManagement dtoStoreManagement = new DtoStoreManagement();
            var lstCategory = _serviceHttpClient.LoadObjectCategory("https://localhost:3000/StoreManagementApi");

            if (dtoStoreManagement is not null)
            {
                // Initializer the list of Category.
                dtoStoreManagement?.ListCategory?.Add(new SelectListItem() { Value = Convert.ToString(0), Text = "Select", Selected = true });

                // Initializer the list of the SubCategory.
                dtoStoreManagement?.ListSubCategory?.Add(new SelectListItem() { Value = Convert.ToString(0), Text = "Select", Selected = true });

                // Initializer the list of the Product.
                dtoStoreManagement?.ListProduct?.Add(new SelectListItem() { Value = Convert.ToString(0), Text = "Select", Selected = true });

                if (lstCategory is not null && lstCategory.Any())
                {
                    for (int i = 0; i < lstCategory.Count; i++)
                    {
                        dtoStoreManagement?.ListCategory?.Add(new SelectListItem() { Value = Convert.ToString(lstCategory[i]?.CategoryID), Text = lstCategory[i]?.CategoryName?.ToString(), Selected = false });
                    }
                }
            }

            return View("~/Views/StoreManagement/Index.cshtml", dtoStoreManagement);
        }
    }
}
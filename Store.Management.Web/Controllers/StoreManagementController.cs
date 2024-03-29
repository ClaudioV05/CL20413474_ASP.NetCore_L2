using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Management.Application.Interfaces;
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
        public async Task<IActionResult> Index()
        {
            ViewModelStoreManagement dtoStoreManagement = new ViewModelStoreManagement();
            try
            {
                var lstCategory = _serviceLinks.LoadObjectCategory("https://localhost:3000/StoreManagementApi/ObtainAllListOfCategory");

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
            catch (Exception)
            {
                // erro viu here
                return View("~/Views/StoreManagement/Index.cshtml", dtoStoreManagement);
            }
        }

        /*
       [HttpPost]
       public IActionResult Save(int value1)
       {
           if (true)
           {
               ModelState.AddModelError("", "Data should be informed");
           }
           else
           {
               // Getting selected Value.
               var SubCategoryID = HttpContext.Request.Form["SubCategoryID"].ToString();
               var ProductID = HttpContext.Request.Form["ProductID"].ToString();

               // Setting Data back to ViewBag after Posting Form.
               List<Category> categorylist = new List<Category>();
               //categorylist = (from category in _context.Category select category).ToList();
               categorylist.Insert(0, new Category { CategoryID = 0, CategoryName = "Select" });
               // Assigning categorylist to ViewBag.ListofCategory.
               ViewBag.ListofCategory = categorylist;
           }

           //return View(category);
           return View(null);
       }
        */

        [HttpGet]
        public JsonResult GetSubCategory(int categoryID)
        {
            ViewModelStoreManagement dtoStoreManagement = new ViewModelStoreManagement();
            var lstSubCategory = _serviceLinks.LoadObjectSubCategoryById($"https://localhost:3000/StoreManagementApi/ObtainListOfSubCategoryById/{categoryID}");
            return Json(lstSubCategory);
        }

        /*[HttpGet]
        public JsonResult GetProducts(int subCategoryID)
        {
            Category ctg = new Category();
            List<Product> lstProduct = new List<Product>();
            ctg.ListOfProduct = new List<SelectListItem>();

            lstProduct = (from product in _context.Product where product.SubCategoryID.Equals(subCategoryID) select product).ToList();

            if (lstProduct is not null && lstProduct.Any())
            {
                for (int i = 0; i < lstProduct.Count; i++)
                {
                    ctg.ListOfProduct.Add(new SelectListItem() { Value = lstProduct[i]?.ProductID.ToString(), Text = lstProduct[i]?.ProductName?.ToString(), Selected = (i == 0) });
                }
            }

            return Json(lstProduct);
        }*/
    }
}
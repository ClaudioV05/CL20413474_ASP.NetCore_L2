using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Management.Models;

namespace Store.Management.Controllers
{
    public class StoreManagementController : Controller
    {
        private readonly DatabaseContext _context;

        public StoreManagementController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Category category1 = new Category();
            List<Category> categorylist = new List<Category>();
            category1.ListOfCategory = new List<SelectListItem>();
            category1.ListOfSubCategory = new List<SelectListItem>();
            category1.ListOfProduct = new List<SelectListItem>();

            categorylist = (from category in _context.Category select category).ToList();

            #region Initializer Category.
            if (categorylist is not null && categorylist.Any())
            {
                category1.ListOfCategory.Add(new SelectListItem()
                {
                    Value = Convert.ToString("0"),
                    Text = "Select",
                    Selected = true
                });

                for (int i = 0; i < categorylist.Count; i++)
                {
                    category1.ListOfCategory.Add(new SelectListItem()
                    {
                        Value = categorylist[i]?.CategoryID.ToString(),
                        Text = categorylist[i]?.CategoryName?.ToString(),
                        Selected = false
                    });
                }
            }
            else
            {
                category1.ListOfCategory.Add(new SelectListItem()
                {
                    Value = Convert.ToString("0"),
                    Text = "Select",
                    Selected = true
                });
            }
            #endregion Initializer Category.

            #region Initializer SubCategory.
            category1.ListOfSubCategory.Add(new SelectListItem()
            {
                Value = Convert.ToString("0"),
                Text = "Select",
                Selected = true
            });
            #endregion Initializer SubCategory.

            #region Initializer ListOfProduct.
            category1.ListOfProduct.Add(new SelectListItem()
            {
                Value = Convert.ToString("0"),
                Text = "Select",
                Selected = true
            });
            #endregion  Initializer ListOfProduct.

            return View("~/Views/StoreManagement/Index.cshtml", category1);
        }

        [HttpPost]
        public IActionResult Index(Category objcategory, IFormCollection formCollection)
        {
            // Validation.
            if (objcategory is null)
            {
                ModelState.AddModelError("", "Data should be informed");
            }
            else if (objcategory.CategoryID.Equals(0))
            {
                ModelState.AddModelError("", "Select Category");
            }
            else if (objcategory.SubCategoryID.Equals(0))
            {
                ModelState.AddModelError("", "Select SubCategory");
            }
            else if (objcategory.ProductID.Equals(0))
            {
                ModelState.AddModelError("", "Select Product");
            }

            // Getting selected Value.
            var SubCategoryID = HttpContext.Request.Form["SubCategoryID"].ToString();
            var ProductID = HttpContext.Request.Form["ProductID"].ToString();

            // Setting Data back to ViewBag after Posting Form.
            List<Category> categorylist = new List<Category>();
            categorylist = (from category in _context.Category select category).ToList();
            categorylist.Insert(0, new Category { CategoryID = 0, CategoryName = "Select" });
            // Assigning categorylist to ViewBag.ListofCategory.
            ViewBag.ListofCategory = categorylist;

            return View(objcategory);
        }

        [HttpGet]
        public JsonResult GetSubCategory(int categoryID)
        {
            Category category1 = new Category();
            category1.ListOfSubCategory = new List<SelectListItem>();
            List<SubCategory> subCategorylist = new List<SubCategory>();

            subCategorylist = (from subcategory in _context.SubCategory where subcategory.CategoryID.Equals(categoryID) select subcategory).ToList();

            if (subCategorylist is not null && subCategorylist.Any())
            {
                for (int i = 0; i < subCategorylist.Count; i++)
                {
                    category1.ListOfSubCategory.Add(new SelectListItem()
                    {
                        Value = subCategorylist[i]?.SubCategoryID.ToString(),
                        Text = subCategorylist[i]?.SubCategoryName?.ToString(),
                        Selected = (i == 0)
                    });
                }
            }

            return Json(subCategorylist);
        }

        public JsonResult GetProducts(int SubCategoryID)
        {
            List<Product> productList = new List<Product>();
            // Getting Data from Database Using EntityFrameworkCore.
            productList = (from product in _context.Product where product.SubCategoryID.Equals(SubCategoryID) select product).ToList();
            // Inserting Select Item in List.
            productList.Insert(0, new Product { ProductID = 0, ProductName = "Select" });

            return Json(new SelectList(productList, "ProductID", "ProductName"));
        }
    }
}
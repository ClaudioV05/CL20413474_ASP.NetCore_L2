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

        [HttpGet]
        public IActionResult Index()
        {
            Category ctg = new Category();
            List<Category> lstCategory = new List<Category>();
            ctg.ListOfCategory = new List<SelectListItem>();
            ctg.ListOfSubCategory = new List<SelectListItem>();
            ctg.ListOfProduct = new List<SelectListItem>();

            lstCategory = (from category in _context.Category select category).ToList();

            #region Initializer Category.
            if (lstCategory is not null && lstCategory.Any())
            {
                ctg.ListOfCategory.Add(new SelectListItem()
                {
                    Value = Convert.ToString("0"),
                    Text = "Select",
                    Selected = true
                });

                for (int i = 0; i < lstCategory.Count; i++)
                {
                    ctg.ListOfCategory.Add(new SelectListItem()
                    {
                        Value = lstCategory[i]?.CategoryID.ToString(),
                        Text = lstCategory[i]?.CategoryName?.ToString(),
                        Selected = false
                    });
                }
            }
            else
            {
                ctg.ListOfCategory.Add(new SelectListItem()
                {
                    Value = Convert.ToString("0"),
                    Text = "Select",
                    Selected = true
                });
            }
            #endregion Initializer Category.

            #region Initializer SubCategory.
            ctg.ListOfSubCategory.Add(new SelectListItem()
            {
                Value = Convert.ToString("0"),
                Text = "Select",
                Selected = true
            });
            #endregion Initializer SubCategory.

            #region Initializer ListOfProduct.
            ctg.ListOfProduct.Add(new SelectListItem()
            {
                Value = Convert.ToString("0"),
                Text = "Select",
                Selected = true
            });
            #endregion  Initializer ListOfProduct.

            return View("~/Views/StoreManagement/Index.cshtml", ctg);
        }

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

        [HttpGet]
        public JsonResult GetSubCategory(int categoryID)
        {
            Category ctg = new Category();
            ctg.ListOfSubCategory = new List<SelectListItem>();
            List<SubCategory> lstSubCategory = new List<SubCategory>();

            lstSubCategory = (from subcategory in _context.SubCategory where subcategory.CategoryID.Equals(categoryID) select subcategory).ToList();

            if (lstSubCategory is not null && lstSubCategory.Any())
            {
                for (int i = 0; i < lstSubCategory.Count; i++)
                {
                    ctg.ListOfSubCategory.Add(new SelectListItem()
                    {
                        Value = lstSubCategory[i]?.SubCategoryID.ToString(),
                        Text = lstSubCategory[i]?.SubCategoryName?.ToString(),
                        Selected = (i == 0)
                    });
                }
            }

            return Json(lstSubCategory);
        }

        [HttpGet]
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
                    ctg.ListOfProduct.Add(new SelectListItem()
                    {
                        Value = lstProduct[i]?.ProductID.ToString(),
                        Text = lstProduct[i]?.ProductName?.ToString(),
                        Selected = (i == 0)
                    });
                }
            }

            return Json(lstProduct);
        }
    }
}
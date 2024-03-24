using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Management.Models;
using Microsoft.AspNetCore.Http;

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
            List<Category> categorylist = new List<Category>();

            // Getting Data from Database Using EntityFrameworkCore.
            categorylist = (from category in _context.Category select category).ToList();
            // Inserting Select Item in List
            categorylist.Insert(0, new Category { CategoryID = 0, CategoryName = "Select" });
            // Assigning categorylist to ViewBag.ListofCategory.
            ViewBag.ListofCategory = categorylist;

            return View("~/Views/StoreManagement/Index.cshtml");
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

        public JsonResult GetSubCategory(int CategoryID)
        {
            List<SubCategory> subCategorylist = new List<SubCategory>();
            // Getting Data from Database Using EntityFrameworkCore.
            subCategorylist = (from subcategory in _context.SubCategory where subcategory.CategoryID.Equals(CategoryID) select subcategory).ToList();
            // Inserting Select Item in List.
            subCategorylist.Insert(0, new SubCategory { SubCategoryID = 0, SubCategoryName = "Select" });

            return Json(new SelectList(subCategorylist, "SubCategoryID", "SubCategoryName"));
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
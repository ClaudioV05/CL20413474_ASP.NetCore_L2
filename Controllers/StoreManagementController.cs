using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Store.Management.Domain.Entities;
using Store.Management.Models;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Store.Management.Controllers
{
    public class StoreManagementController : Controller
    {
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly IHttpClientFactory _httpClient;

        public StoreManagementController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;

            _jsonOptions = new JsonSerializerOptions()
            {
                AllowTrailingCommas = false,
                MaxDepth = 64,
                Encoder = JavaScriptEncoder.Default,
                WriteIndented = true,
                IncludeFields = false,
                IgnoreReadOnlyFields = false,
                IgnoreReadOnlyProperties = false,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            DtoStoreManagement dtoStoreManagement = new DtoStoreManagement();
            var lstCategory = await this.LoadObjectCategory(_httpClient.CreateClient("StoreManagement"));

            // Initializer the list of Category.
            if (lstCategory is not null && lstCategory.Any())
            {
                dtoStoreManagement?.ListCategory?.Add(new SelectListItem()
                {
                    Value = Convert.ToString("0"),
                    Text = "Select",
                    Selected = true
                });

                for (int i = 0; i < lstCategory.Count; i++)
                {
                    dtoStoreManagement?.ListCategory?.Add(new SelectListItem()
                    {
                        Value = lstCategory[i]?.CategoryID.ToString(),
                        Text = lstCategory[i]?.CategoryName?.ToString(),
                        Selected = false
                    });
                }
            }
            else
            {
                dtoStoreManagement?.ListCategory?.Add(new SelectListItem()
                {
                    Value = Convert.ToString("0"),
                    Text = "Select",
                    Selected = true
                });
            }

            // Initializer the list of the SubCategory.
            dtoStoreManagement?.ListSubCategory?.Add(new SelectListItem()
            {
                Value = Convert.ToString("0"),
                Text = "Select",
                Selected = true
            });

            // Initializer the list of the Product.
            dtoStoreManagement?.ListProduct?.Add(new SelectListItem()
            {
                Value = Convert.ToString("0"),
                Text = "Select",
                Selected = true
            });
            
            return View("~/Views/StoreManagement/Index.cshtml", dtoStoreManagement);
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

        */

        #region Utils.

        public async Task<List<Category>> LoadObjectCategory(HttpClient httpClient)
        {
            var listItem = new List<Category>();

            if (httpClient is not null)
            {
                try
                {
                    using var response = await httpClient.GetAsync($"StoreManagement", HttpCompletionOption.ResponseHeadersRead);

                    if (response is not null && response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            listItem = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Category>>(await response.Content.ReadAsStreamAsync(), _jsonOptions);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro: {ex.Message}");
                }
            }

            return listItem;
        }

        public StringContent ConvertObjectToStringContent(HttpClient httpClient, object obj)
        {
            const string MIME_TYPE_DEFAULT = "application/json";

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MIME_TYPE_DEFAULT));
            
            var jsonContent = JsonConvert.SerializeObject(obj);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, MIME_TYPE_DEFAULT);
            contentString.Headers.ContentType = new MediaTypeHeaderValue(MIME_TYPE_DEFAULT);

            return contentString;
        }

        #endregion Utils.
    }
}
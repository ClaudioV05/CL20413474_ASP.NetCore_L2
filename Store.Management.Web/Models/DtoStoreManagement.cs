using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Management.Web.Models
{
    /// <summary>
    /// Data transfer objct - Store Management.
    /// </summary>
    public class DtoStoreManagement
    {
        /// <summary>
        /// List of the Product.
        /// </summary>
        public List<SelectListItem>? ListProduct { get; set; }

        /// <summary>
        /// List of the Category.
        /// </summary>
        public List<SelectListItem>? ListCategory { get; set; }

        /// <summary>
        /// List of the SubCategory.
        /// </summary>
        public List<SelectListItem>? ListSubCategory { get; set; }

        public DtoStoreManagement()
        {
            this.ListProduct = new List<SelectListItem>();
            this.ListCategory = new List<SelectListItem>();
            this.ListSubCategory = new List<SelectListItem>();
        }
    }
}
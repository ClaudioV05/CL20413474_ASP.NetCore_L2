using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Store.Management.Web.ViewModels
{
    /// <summary>
    /// View Model - Store Management.
    /// </summary>
    public class StoreManagementViewModel
    {
        /// <summary>
        /// Product.
        /// </summary>
        [Display(Name = "Product Name")]
        public string? Product { get; set; }

        /// <summary>
        /// Category.
        /// </summary>
        [Display(Name = "Category Name")]
        public string? Category { get; set; }

        /// <summary>
        /// SubCategory.
        /// </summary>
        [Display(Name = "Sub Category Name")]
        public string? SubCategory { get; set; }

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

        public StoreManagementViewModel()
        {
            this.ListProduct = new List<SelectListItem>();
            this.ListCategory = new List<SelectListItem>();
            this.ListSubCategory = new List<SelectListItem>();
        }
    }
}
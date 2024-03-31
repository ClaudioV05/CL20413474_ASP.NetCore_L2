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
        /// List of the Products.
        /// </summary>
        public List<SelectListItem>? ListProducts { get; set; }

        /// <summary>
        /// List of the Categories.
        /// </summary>
        public List<SelectListItem>? ListCategories { get; set; }

        /// <summary>
        /// List of the SubCategories.
        /// </summary>
        public List<SelectListItem>? ListSubCategories { get; set; }

        public StoreManagementViewModel()
        {
            this.ListProducts = new List<SelectListItem>();
            this.ListCategories = new List<SelectListItem>();
            this.ListSubCategories = new List<SelectListItem>();
        }
    }
}
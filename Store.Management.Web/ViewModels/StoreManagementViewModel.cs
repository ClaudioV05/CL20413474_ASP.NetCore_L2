using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Management.Web.ViewModels
{
    /// <summary>
    /// View Model - Store Management.
    /// </summary>
    public class StoreManagementViewModel
    {
        /// <summary>
        /// Initialize the view.
        /// </summary>
        public bool InitializeView { get; set; }

        /// <summary>
        /// Product.
        /// </summary>
        public string? Product { get; set; }

        /// <summary>
        /// Category.
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// SubCategory.
        /// </summary>
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
            this.InitializeView = true;
            this.ListProduct = new List<SelectListItem>();
            this.ListCategory = new List<SelectListItem>();
            this.ListSubCategory = new List<SelectListItem>();
        }
    }
}
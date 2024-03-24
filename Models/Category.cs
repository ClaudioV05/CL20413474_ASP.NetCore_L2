using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Management.Models
{
    public class Category
    {
        /// <summary>
        /// CategoryID.
        /// </summary>
        [Key]
        public int CategoryID { get; set; }

        /// <summary>
        /// CategoryName.
        /// </summary>
        public string? CategoryName { get; set; }

        /// <summary>
        /// ProductID.
        /// </summary>
        [NotMapped]
        public int ProductID { get; set; }

        /// <summary>
        /// SubCategoryID.
        /// </summary>
        [NotMapped]
        public int SubCategoryID { get; set; }

        /// <summary>
        /// ListOfCategory.
        /// </summary>
        [NotMapped]
        public List<SelectListItem> ListOfCategory { get; set; }

        /// <summary>
        /// ListOfSubCategory.
        /// </summary>
        [NotMapped]
        public List<SelectListItem> ListOfSubCategory { get; set; }

        /// <summary>
        /// ListOfProduct.
        /// </summary>
        [NotMapped]
        public List<SelectListItem> ListOfProduct { get; set; }
    }
}
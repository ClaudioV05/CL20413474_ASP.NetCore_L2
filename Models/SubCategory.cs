using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Management.Models
{
    public class SubCategory
    {
        /// <summary>
        /// SubCategoryID.
        /// </summary>
        [Key]
        public int SubCategoryID { get; set; }

        /// <summary>
        /// CategoryID.
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// SubCategoryName.
        /// </summary>
        public string? SubCategoryName { get; set; }
    }
}
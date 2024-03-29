using System.ComponentModel.DataAnnotations;

namespace Store.Management.Domain.Entities
{
    /// <summary>
    /// SubCategory.
    /// </summary>
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
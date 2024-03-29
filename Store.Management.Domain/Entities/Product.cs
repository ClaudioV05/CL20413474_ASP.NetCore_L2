using System.ComponentModel.DataAnnotations;

namespace Store.Management.Domain.Entities
{
    /// <summary>
    /// Product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ProductID.
        /// </summary>
        [Key]
        public int ProductID { get; set; }

        /// <summary>
        /// ProductName.
        /// </summary>
        public string? ProductName { get; set; }

        /// <summary>
        /// SubCategoryID.
        /// </summary>
        public int SubCategoryID { get; set; }
    }
}
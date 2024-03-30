using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [StringLength(40)]
        [Column(TypeName = "varchar(40)")]

        public string? ProductName { get; set; }

        /// <summary>
        /// SubCategoryID.
        /// </summary>
        public int SubCategoryID { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Management.Domain.Entities
{
    /// <summary>
    /// Products.
    /// </summary>
    [Table("Products", Schema = "dbo")]
    public class Products
    {
        /// <summary>
        /// ProductID.
        /// </summary>
        [Key]
        [Required]
        [Column(Order = 0)]
        public long ProductID { get; set; }

        /// <summary>
        /// SubCategoryID.
        /// </summary>
        [Required]
        [Column(Order = 1)]
        public long SubCategoryID { get; set; }

        /// <summary>
        /// ProductName.
        /// </summary>
        [StringLength(40)]
        [Column(TypeName = "varchar(40)", Order = 2)]
        [Required(AllowEmptyStrings = false)]
        public string? ProductName { get; set; }

        /// <summary>
        /// Quantity.
        /// </summary>
        [Required]
        [Column(Order = 3)]
        public double Quantity { get; set; }
    }
}
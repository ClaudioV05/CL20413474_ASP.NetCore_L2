using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Management.Domain.Entities
{
    /// <summary>
    /// Product.
    /// </summary>
    //[NotMapped]
    public class Product
    {
        /// <summary>
        /// ProductID.
        /// </summary>
        [Key]
        [Required]
        public long ProductID { get; set; }

        /// <summary>
        /// SubCategoryID.
        /// </summary>
        [Required]
        public long SubCategoryID { get; set; }

        /// <summary>
        /// ProductName.
        /// </summary>
        [StringLength(40)]
        [Column(TypeName = "varchar(40)")]
        [Required(AllowEmptyStrings = false)]
        public string? ProductName { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Management.Domain.Entities
{
    /// <summary>
    /// Categories.
    /// </summary>
    [Table("Categories", Schema = "dbo")]
    public class Categories
    {
        /// <summary>
        /// CategoryID.
        /// </summary>
        [Key]
        [Required]
        [Column(Order = 0)]
        public long CategoryID { get; set; }

        /// <summary>
        /// CategoryName.
        /// </summary>
        [StringLength(40)]
        [Column(TypeName = "varchar(40)", Order = 1)]
        [Required(AllowEmptyStrings = false)]
        public string? CategoryName { get; set; }
    }
}
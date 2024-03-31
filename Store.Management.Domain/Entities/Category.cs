using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Management.Domain.Entities
{
    /// <summary>
    /// Category.
    /// </summary>
    //[NotMapped]
    public class Category
    {
        /// <summary>
        /// CategoryID.
        /// </summary>
        [Key]
        [Required]
        public long CategoryID { get; set; }

        /// <summary>
        /// CategoryName.
        /// </summary>
        [StringLength(40)]
        [Column(TypeName = "varchar(40)")]
        [Required(AllowEmptyStrings = false)]
        public string? CategoryName { get; set; }
    }
}
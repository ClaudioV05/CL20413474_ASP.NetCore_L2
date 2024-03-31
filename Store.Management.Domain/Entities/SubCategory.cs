using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Management.Domain.Entities
{
    /// <summary>
    /// SubCategory.
    /// </summary>
    //[NotMapped]
    public class SubCategory
    {
        /// <summary>
        /// SubCategoryID.
        /// </summary>
        [Key]
        [Required]
        public long SubCategoryID { get; set; }

        /// <summary>
        /// CategoryID.
        /// </summary>
        public long CategoryID { get; set; }

        /// <summary>
        /// SubCategoryName.
        /// </summary>
        [StringLength(40)]
        [Column(TypeName = "varchar(40)")]
        [Required(AllowEmptyStrings = false)]
        public string? SubCategoryName { get; set; }
    }
}
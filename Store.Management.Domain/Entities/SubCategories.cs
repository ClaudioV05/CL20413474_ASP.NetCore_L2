using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Management.Domain.Entities
{
    /// <summary>
    /// SubCategories.
    /// </summary>
    [Table("SubCategories", Schema = "dbo")]
    public class SubCategories
    {
        /// <summary>
        /// SubCategoryID.
        /// </summary>
        [Key]
        [Required]
        [Column(Order = 0)]
        public long SubCategoryID { get; set; }

        /// <summary>
        /// CategoryID.
        /// </summary>
        [Column(Order = 1)]
        public long CategoryID { get; set; }

        /// <summary>
        /// SubCategoryName.
        /// </summary>
        [StringLength(40)]
        [Column(TypeName = "varchar(40)", Order = 2)]
        [Required(AllowEmptyStrings = false)]
        public string? SubCategoryName { get; set; }
    }
}
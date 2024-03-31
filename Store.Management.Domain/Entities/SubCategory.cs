using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Management.Domain.Entities
{
    /// <summary>
    /// SubCategory.
    /// </summary>
    [NotMapped]
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
        [StringLength(40)]
        [Column(TypeName = "varchar(40)")]
        public string? SubCategoryName { get; set; }
    }
}
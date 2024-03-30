using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Store.Management.Domain.Entities;

namespace Store.Management.Domain.Entities
{
    /// <summary>
    /// Category.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// CategoryID.
        /// </summary>
        [Key]
        public int CategoryID { get; set; }

        /// <summary>
        /// CategoryName.
        /// </summary>
        [StringLength(40)]
        [Column(TypeName = "varchar(40)")]
        public string? CategoryName { get; set; }
    }
}
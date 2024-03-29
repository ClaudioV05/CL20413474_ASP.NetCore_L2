using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public string? CategoryName { get; set; }
    }
}
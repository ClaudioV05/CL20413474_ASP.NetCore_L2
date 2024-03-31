using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Store.Management.Domain.Entities;

namespace Store.Management.Domain.Entities
{
    /// <summary>
    /// User.
    /// </summary>
    [NotMapped]
    public class User
    {
        [Key]
        public int UserID { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [StringLength(40)]
        [Column(TypeName = "varchar(40)")]
        public string? Name { get; set; }
    }
}
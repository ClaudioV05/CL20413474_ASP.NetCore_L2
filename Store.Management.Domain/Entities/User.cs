using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Store.Management.Domain.Entities;

namespace Store.Management.Domain.Entities
{
    /// <summary>
    /// User.
    /// </summary>
    [NotMapped]
    // [Table("User", Schema = "dbo")]
    public class User
    {
        /// <summary>
        /// User Id.
        /// </summary>
        [Key]
        [Required]
        [Column(Order = 0)]
        public long Id { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [Column(Order = 1)]
        public string? Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [Column(Order = 2)]
        public string? Password { get; set; }
    }
}
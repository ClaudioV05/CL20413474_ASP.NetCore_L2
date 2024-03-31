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
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        public string? Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        public string? Password { get; set; }
    }
}
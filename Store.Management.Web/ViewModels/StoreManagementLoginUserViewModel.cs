using System.ComponentModel.DataAnnotations;

namespace Store.Management.Web.ViewModels
{
    /// <summary>
    /// View Model - Store management login user.
    /// </summary>
    public class StoreManagementLoginUserViewModel
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string? Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        /// <summary>
        /// Remember me.
        /// </summary>
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
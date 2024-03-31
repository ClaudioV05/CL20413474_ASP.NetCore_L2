using System.ComponentModel.DataAnnotations;

namespace Store.Management.Web.ViewModels
{
    /// <summary>
    /// View Model - Store management register user.
    /// </summary>
    public class StoreManagementRegisterUser
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
        /// Confirm the password.
        /// </summary>
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
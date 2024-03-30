using System.ComponentModel.DataAnnotations;

namespace Store.Management.Web.ViewModels
{
    /// <summary>
    /// View Model - Store management login user.
    /// </summary>
    public class StoreManagementLoginUserViewModel
    {
        /// <summary>
        /// Username.
        /// </summary>
        [Display(Name = "Enter your username")]
        public string? Username { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Display(Name = "Password")]
        public string? Password { get; set; }
    }
}
using Microsoft.AspNetCore.Identity;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;

namespace Store.Management.Infrastructure.Data.Repositories
{
    /// <summary>
    /// RepositoryUser.
    /// </summary>
    public class RepositoryUser : IRepositoryUser
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        /// <summary>
        /// RepositoryUser.
        /// </summary>
        /// <param name=""></param>
        public RepositoryUser(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task RegisterUser(User user)
        {
            try
            {
                var newUser = new IdentityUser()
                {
                    UserName = user.Email,
                    Email = user.Email
                };

                var result = await _userManager.CreateAsync(newUser, user.Password);

                if (result is not null)
                {
                    if (result.Succeeded)
                    {
                        _signInManager.SignInAsync(newUser, isPersistent: false);
                    }
                    else if (result.Errors.Any())
                    {
                        throw new Exception(result.Errors.FirstOrDefault().Description);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
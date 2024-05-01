using Microsoft.AspNetCore.Identity;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;

namespace Store.Management.Infrastructure.Data.Repositories;

/// <summary>
/// RepositoryUsers.
/// </summary>
public class RepositoryUsers : IRepositoryUsers
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    /// <summary>
    /// RepositoryUsers.
    /// </summary>
    /// <param name=""></param>
    public RepositoryUsers(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
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

    public async Task LoginUser(User user)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);

            if (!result.Succeeded)
            {
                throw new Exception("User don't registred.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
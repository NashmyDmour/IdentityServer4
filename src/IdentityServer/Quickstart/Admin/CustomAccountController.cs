
using IdentityModel;
using IdentityServer.Models;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.Admin
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class CustomAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
       
       
        public CustomAccountController(UserManager<ApplicationUser> userManager )
        {
            _userManager = userManager;

        }

        /*********************************************/
        /* user managment */
        /***************************************/
        [HttpPost]
        public async Task<string> RegisterUserAsync(string username, string password)
        {
            var user = new ApplicationUser { UserName = username, Email = username, EmailConfirmed = true, IsEnabled = true };
            var result = await _userManager.CreateAsync(user, password);
            var Errorlist = "##";
            if (result.Succeeded)
            {
                //  _logger.LogInformation("User created a new account with password.");

                return "done";
            }
            foreach (var error in result.Errors)
            {
                Errorlist = Errorlist + "\n" + error.Description;
            }
            return Errorlist;
        }

        [HttpPost]
        //[Authorize]
        public async Task<string> ChangeUserPasswordAsync(string username, string currentpassword, string newpassword)
        {
            var user = await _userManager.FindByNameAsync(username);
            var result = await _userManager.ChangePasswordAsync(user, currentpassword, newpassword);
            var Errorlist = "##";
            if (result.Succeeded)
            {
                //  _logger.LogInformation("User created a new account with password.");

                return "done";
            }
            foreach (var error in result.Errors)
            {
                Errorlist = Errorlist + "\n" + error.Description;
            }
            return Errorlist;
        }

        public async Task<string> ResetUserPasswordAsync(string username, string newpassword, string resettoken)
        {
            var user = await _userManager.FindByNameAsync(username);
            var result = await _userManager.ResetPasswordAsync(user, resettoken, newpassword);
            var Errorlist = "##";
            if (result.Succeeded)
            {
                //  _logger.LogInformation("User created a new account with password.");

                return "done";
            }
            foreach (var error in result.Errors)
            {
                Errorlist = Errorlist + "\n" + error.Description;
            }
            return Errorlist;
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            var result = await _userManager.GeneratePasswordResetTokenAsync(user);
            var Errorlist = "##";
            if (result.IsNullOrEmpty())
            {
                //  _logger.LogInformation("User created a new account with password.");
                return Errorlist + " Enable to generate restet password token ";

            }
            else
                return result;

        }
    }
}
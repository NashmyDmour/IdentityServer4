using IdentityModel;
using IdentityServer.Models;
using IdentityServer4.Events;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{

    public class CustomTokenRequestValidator : IResourceOwnerPasswordValidator
    {
        //public UserManager<ApplicationUser> _userManager;
        ////HttpContext _context;
        //public CustomTokenRequestValidator(UserManager<ApplicationUser> userManager)
        //{
        //    _userManager = userManager;

        //}
        //public  Task ValidateAsync(CustomTokenRequestValidationContext context)
        //{
        //   var x= context.Result.ValidatedRequest;

        //   // var user =  await _userManager.FindByNameAsync(x.UserName);

        //        if (!context.Result.IsError)
        //    {

        //        //if (user != null && user.LockoutEnd.HasValue)

        //        context.Result.Error = OidcConstants.AuthorizeErrors.UnauthorizedClient;

        //    }

        //    return Task.CompletedTask;
        //}

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //var x = context.Result.Subject;
            
             //var user =  await _userManager.FindByNameAsync(x.UserName);

            if (!context.Result.IsError)
            {

                //if (user != null && user.LockoutEnd.HasValue)

                context.Result.Error = OidcConstants.AuthorizeErrors.UnauthorizedClient;

            }
            context.Result.Error = OidcConstants.AuthorizeErrors.ConsentRequired;
            return Task.CompletedTask;
        }
    }
}
public class CustomAuthorizeRequestValidator : ICustomAuthorizeRequestValidator
{
    public Task ValidateAsync(CustomAuthorizeRequestValidationContext context)
    {
        //var x = context.Result.Subject;

        //var user =  await _userManager.FindByNameAsync(x.UserName);

        if (!context.Result.IsError)
        {

            //if (user != null && user.LockoutEnd.HasValue)

            context.Result.Error = OidcConstants.AuthorizeErrors.UnauthorizedClient;
        }
        context.Result.Error = OidcConstants.AuthorizeErrors.ConsentRequired;
        return Task.CompletedTask;
    }
    }





using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.Models;
using IdentityServer4.Services;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Quickstart.Admin
{
    public class ClientsController : Controller
    {
        //private readonly IConfigurationDbContext _configurationDbContext;
        //private readonly IIdentityServerInteractionService _IdentityServerInteractionService;
       //public ClientsController(IConfigurationDbContext configurationDbContext, IIdentityServerInteractionService IdentityServerInteractionService)
       // {
       //     _configurationDbContext = configurationDbContext;
       //     _IdentityServerInteractionService = IdentityServerInteractionService;
       // }

     
        public  string Index(string _secret)
        {
            //var cc = await _IdentityServerInteractionService.GetAuthorizationContextAsync("");

            //var uu = _configurationDbContext.Clients.Where(s => s.ClientId == "mvc").FirstOrDefault();
            var x=new Secret(_secret.Sha256());
            return x.Value;
        }
    }
}
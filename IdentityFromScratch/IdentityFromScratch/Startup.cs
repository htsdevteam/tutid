using IdentityFromScratch.Models;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(IdentityFromScratch.Startup))]
namespace IdentityFromScratch
{
    public class Startup
    {
        public void Configuration(Owin.IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(
                ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(
                ApplicationSignInManager.Create);
        }
    }
}
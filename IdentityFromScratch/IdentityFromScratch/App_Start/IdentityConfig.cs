using IdentityFromScratch.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityFromScratch
{
    public class ApplicationUserManager : UserManager<CustomUser>
    {
        public ApplicationUserManager(UserStore<CustomUser> userStore)
            : base(userStore) { }

        public static ApplicationUserManager Create(
            IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext owinContext)
        {
            var userStore = new UserStore<CustomUser>(owinContext.Get<ApplicationDbContext>());
            return new ApplicationUserManager(userStore);
        }
    }


    public class ApplicationSignInManager : SignInManager<CustomUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager,
            IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager) { }

        public static ApplicationSignInManager Create(
            IdentityFactoryOptions<ApplicationSignInManager> options,
            IOwinContext owinContext)
        {

            return new ApplicationSignInManager(owinContext.Get<ApplicationUserManager>(),
                owinContext.Authentication);
        }
    }


    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(RoleStore<IdentityRole> roleStore)
            : base(roleStore) { }

        public static ApplicationRoleManager Create(IOwinContext owinContext)
        {
            var roleStore = new RoleStore<IdentityRole>(owinContext.Get<ApplicationDbContext>());
            return new ApplicationRoleManager(roleStore);
        }
    }


    public class IdentityConfig
    {
        // IUser
        // IUserStore
        // UserManager
        // SignInManager

        // IdentityUser
        // UserStore<IdentityUser>
        // IdentityDbContext<IdentityUser>


    }
}
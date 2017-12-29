using IdentityFromScratch.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentityFromScratch.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            string email = "foo@bar.com";
            string password = "Passw0rd";
            CustomUser user = await UserManager.FindByEmailAsync(email);

            var roleManager = ApplicationRoleManager.Create(HttpContext.GetOwinContext());
            if (!await roleManager.RoleExistsAsync(SecurityRoles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole { Name = SecurityRoles.Admin });
            }
            if (!await roleManager.RoleExistsAsync(SecurityRoles.IT))
            {
                await roleManager.CreateAsync(new IdentityRole { Name = SecurityRoles.IT });
            }
            if (!await roleManager.RoleExistsAsync(SecurityRoles.Accounting))
            {
                await roleManager.CreateAsync(new IdentityRole { Name = SecurityRoles.Accounting });
            }


            if (user == null)
            {
                user = new CustomUser {
                    FirstName = "Super",
                    LastName = "Admin",
                    UserName = email,
                    Email = email
                };
                await UserManager.CreateAsync(user, password);
            }

            if (!await UserManager.IsInRoleAsync(user.Id, SecurityRoles.Admin))
            {
                await UserManager.AddToRoleAsync(user.Id, SecurityRoles.Admin);
            }
            //if (!await UserManager.IsInRoleAsync(user.Id, SecurityRoles.IT))
            //{
            //    await UserManager.AddToRoleAsync(user.Id, SecurityRoles.IT);
            //}
            //if (!await UserManager.IsInRoleAsync(user.Id, SecurityRoles.Accounting))
            //{
            //    await UserManager.AddToRoleAsync(user.Id, SecurityRoles.Accounting);
            //}

            return Content("Hello Index");
        }

        public async Task<ActionResult> Login()
        {
            string email = "foo@bar.com";
            CustomUser user = await UserManager.FindByEmailAsync(email);

            await SignInManager.SignInAsync(user, true, true);
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
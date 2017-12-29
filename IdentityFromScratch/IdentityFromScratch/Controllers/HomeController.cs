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
            else
            {
                SignInStatus result = await SignInManager.PasswordSignInAsync(user.Email,
                    password, true, false);
                //user.FirstName = "Super";
                //user.LastName = "Admin";
                //await manager.UpdateAsync(user);

                if (result == SignInStatus.Success)
                {
                    return Content("Hello, " + user.FirstName + " " + user.LastName);
                }
            }
            return Content("Hello Index");
        }
    }
}
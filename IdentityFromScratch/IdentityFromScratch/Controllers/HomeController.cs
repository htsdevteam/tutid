using IdentityFromScratch.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentityFromScratch.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var context = new ApplicationDbContext();
            var store = new UserStore<CustomUser>(context);
            var manager = new UserManager<CustomUser>(store);
            var signInManager = new SignInManager<CustomUser, string>(manager,
                HttpContext.GetOwinContext().Authentication);

            string email = "foo@bar.com";
            string password = "Passw0rd";
            CustomUser user = await manager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new CustomUser {
                    FirstName = "Super",
                    LastName = "Admin",
                    UserName = email,
                    Email = email
                };
                await manager.CreateAsync(user, password);
            }
            else
            {
                var result = await signInManager.PasswordSignInAsync(user.Email,
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
using IdentityFromScratch.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
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
                user.FirstName = "Super";
                user.LastName = "Admin";
                await manager.UpdateAsync(user);
            }
            return Content("Hello Index");
        }
    }
}
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
            var store = new UserStore<IdentityUser>(context);
            var manager = new UserManager<IdentityUser>(store);

            string email = "foo@bar.com";
            string password = "Passw0rd";
            IdentityUser user = await manager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new IdentityUser { UserName = email, Email = email };
                await manager.CreateAsync(user, password);
            }
            return Content("Hello Index");
        }
    }
}
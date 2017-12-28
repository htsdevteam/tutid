using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityFromScratch.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext() : base() { }
    }
}
﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityFromScratch.Models
{
    public class ApplicationDbContext : IdentityDbContext<CustomUser>
    {
        public ApplicationDbContext() : base() { }
    }

    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
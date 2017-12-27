using Microsoft.Owin;
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

        }
    }
}
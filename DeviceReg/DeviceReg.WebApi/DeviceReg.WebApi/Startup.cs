using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DeviceReg.WebApi.Startup))]

namespace DeviceReg.WebApi
{
    public partial class Startup
    {
        //Test
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sentio.Startup))]
namespace Sentio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.MapSignalR();
        }
    }
}

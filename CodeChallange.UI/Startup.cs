﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;

namespace CodeChallange.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
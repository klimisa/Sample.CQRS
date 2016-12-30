using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Sample.CQRS.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static SampleCqrsRuntime Runtime { get; set; }

        protected void Application_Start()
        {
            Runtime = new SampleCqrsRuntime();
            Runtime.Start();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}

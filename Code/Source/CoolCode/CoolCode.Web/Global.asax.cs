using System;
using System.Web;
using System.Web.Routing;
using CoolCode.Web.Configuration;

namespace CoolCode.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Bootstrap(RouteTable.Routes);
        }
    }
}

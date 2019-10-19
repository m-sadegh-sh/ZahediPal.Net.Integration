using System;
using System.Web;
using System.Web.Routing;

namespace ZahediPal.Net.Integration.WebForms {
    public class Global : HttpApplication {
        private void Application_Start(object sender, EventArgs e) {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
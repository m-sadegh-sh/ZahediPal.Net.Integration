using System.Web.Routing;

using Microsoft.AspNet.FriendlyUrls;

namespace ZahediPal.Net.Integration.WebForms {
    public static class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.EnableFriendlyUrls(new FriendlyUrlSettings {AutoRedirectMode = RedirectMode.Permanent});
        }
    }
}
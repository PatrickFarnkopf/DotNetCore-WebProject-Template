using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;

namespace Presentation.Web.Configuration
{
    public static class RoutesConfiguration
    {
        public static void Configure(IRouteBuilder routes)
        {
            routes.MapRoute(
                name: "default",
                template: "{controller}/{action=Index}/{id?}");
        }
    }
}
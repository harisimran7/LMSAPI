using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSAPI
{
    public class RouteProvider : IRouteProvider
    {
        public int Priority => throw new NotImplementedException();

        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            //routeBuilder.MapRoute("default", new { controller = "Home", action = "Index" });
            //template: "{controller=Home}/{action=Index}/{id?}"););

            //routeBuilder.MapRoute("default", template: "{controller=Home}/{action=Index}/{id?}");

            ////home page
            //routeBuilder.MapLocalizedRoute("HomePage", "",
            //    new { controller = "Home", action = "Index" });
        }
    }
}

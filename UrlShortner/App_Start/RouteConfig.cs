using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlShortner
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "UrlPage",
                url: "Url",
                defaults: new { controller = "UrlShortner", action = "Index" }
            );

            routes.MapRoute(
               name: "getlongurl",
               url: "Url/getlongurl",
               defaults: new { controller = "UrlShortner", action = "RedirectUrl" }
           );

            routes.MapRoute(
             name: "UrlShorten",
             url: "Url/shorten",
             defaults: new { controller = "UrlShortner", action = "Shorten" }
         );

            routes.MapRoute(
            name: "urlget",
            url: "Url/get",
            defaults: new { controller = "UrlShortner", action = "GetAll" }
        );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "UrlShortner", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

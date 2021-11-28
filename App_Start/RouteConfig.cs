using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Book_Rental
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*Order of route matters
             Order: Most Specific to Most Generic*/

            /*For Newer and cleaner way of creating routes we need to enable Attributes*/
            routes.MapMvcAttributeRoutes(); //enabling the attributes

            /*Old way of creating routes
            routes.MapRoute(
                "BooksByPublishedDate",
                "books/released/{year}/{month}",
                new { controller = "Books", action = "ByPublishedDate" },
                new { year = @"\d{4}"//REGEX indicating that year has to have 4 digits//, month = @"\d{2}" }
                // if needed to constraint year to 2015 and 2016 year = @"2015|2016"
            );*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Skunk.Website.App_Start
{
    public class RouteConfig
    {
        /// <summary>
        /// Registers the routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("registration-form",
                "registration-form",
                new
                {
                    controller = "UtilitySurface",
                    action = "GetRegistrationForm"
                });
        }
    }
}
using System.Web.Mvc;
using System.Web.Routing;

using HealthKitAPI.Infrastructure;

namespace HealthKitAPI
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
        name: RoutesNames.AllEvents,
        url: RoutesTemplates.AllEvents,
        defaults: new { controller = "HealthKit", action = "AllEvents" });

      routes.MapRoute(
        name: RoutesNames.EventById,
        url: RoutesTemplates.GetEventById,
        defaults: new { controller = "HealthKit", action = "GetEventById" });

      routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
    }
  }
}

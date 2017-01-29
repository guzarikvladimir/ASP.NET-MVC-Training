using System.Web.Mvc;
using System.Web.Routing;

namespace MVCPL
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "UsersTasks",
                url: "{email}/MyTasks",
                defaults: new { controller = "Home", action = "Tasks" });

            routes.MapRoute(
                name: "TasksDefault1",
                url: "Tasks/{action}",
                defaults: new { controller = "Task", action = "TaskManagement" });

            routes.MapRoute(
                name: "UsersDefault",
                url: "Users/{action}",
                defaults: new { controller = "Admin", action = "UserManagement" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );
        }
    }
}

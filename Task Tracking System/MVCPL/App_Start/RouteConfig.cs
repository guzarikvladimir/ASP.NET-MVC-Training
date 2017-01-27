using System.Web.Mvc;
using System.Web.Routing;

namespace MVCPL
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "AccountDefault1",
            //    url: "{action}",
            //    defaults: new { controller = "Account" });

            //routes.MapRoute(
            //    name: "AccountDefault2",
            //    url: "{action}/{*catchall}",
            //    defaults: new { controller = "Account" });

            routes.MapRoute(
                name: "UsersTasks",
                url: "{email}/MyTasks",
                defaults: new { controller = "Home", action = "Tasks" });

            //routes.MapRoute(
            //    name: "HomeDefault1",
            //    url: "{id}/{action}",
            //    defaults: new { controller = "Home" });

            //routes.MapRoute(
            //    name: "HomeDefault3",
            //    url: "{action}",
            //    defaults: new { controller = "Home" });

            //routes.MapRoute(
            //    name: "HomeDefault2",
            //    url: "{action}/{*catchall}",
            //    defaults: new { controller = "Home" });

            //routes.MapRoute(
            //    name: "TasksDefault1",
            //    url: "Tasks/{action}",
            //    defaults: new { controller = "Task", action = "TaskManagement" });

            //routes.MapRoute(
            //    name: "TasksDefault2",
            //    url: "Tasks/{action}/{*catchall}",
            //    defaults: new { controller = "Task", action = "TaskManagement" });

            //routes.MapRoute(
            //    name: "UsersDefault1",
            //    url: "Users/{action}",
            //    defaults: new { controller = "Admin", action = "UserManagement" });

            //routes.MapRoute(
            //    name: "UsersDefault2",
            //    url: "Users/{action}/{*catchall}",
            //    defaults: new {controller = "Admin", action = "UserManagement"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );
        }
    }
}

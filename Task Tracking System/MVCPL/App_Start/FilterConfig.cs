using System.Web.Mvc;
using MVCPL.Filters;

namespace MVCPL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            //filters.Add(new HandleAllErrorAttribute());
            filters.Add(new ExceptionLoggerAttribute());
        }
    }
}
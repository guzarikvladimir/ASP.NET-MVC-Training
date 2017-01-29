using System;
using System.Web.Mvc;
using BLL.Interfaces.Services;
using MVCPL.Infrastructure.Mappers;
using MVCPL.Models;

namespace MVCPL.Filters
{
    public class ExceptionLoggerAttribute : IExceptionFilter
    {
        public IExceptionService ExceptionService
            => (IExceptionService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IExceptionService));

        public void OnException(ExceptionContext exceptionContext)
        {
            var exception = new ExceptionViewModel()
            {
                ExceptionMessage = exceptionContext.Exception.Message,
                StackTrace = exceptionContext.Exception.StackTrace,
                ControllerName = exceptionContext.RouteData.Values["controller"].ToString(),
                ActionName = exceptionContext.RouteData.Values["action"].ToString(),
                Date = DateTime.Now
            };
            ExceptionService.CreateException(exception.ToBllException());

            exceptionContext.ExceptionHandled = false;
        }
    }
}
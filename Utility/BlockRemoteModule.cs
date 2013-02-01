using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Security;

namespace Epic.Utility
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public sealed class BlockRemoteFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.ServerVariables["LOCAL_ADDR"] != filterContext.HttpContext.Request.ServerVariables["REMOTE_ADDR"])
            {
                filterContext.HttpContext.Response.StatusCode = 503;
                filterContext.HttpContext.Response.Write("Access Forbidden");
                filterContext.HttpContext.Response.End();
                filterContext.Result = new EmptyResult();
                throw new SecurityException("Access Forbidden");
            }
        }
        
    }
}
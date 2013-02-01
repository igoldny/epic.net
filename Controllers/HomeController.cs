using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using SquishIt.Framework;

namespace Epic.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Mutex jsMutex = new Mutex();
        private static readonly Mutex cssMutex = new Mutex();
        private static readonly Mutex secureCssMutex = new Mutex();     
        
        public ActionResult Index()
        {
            return View();
        }

        //[OutputCache(CacheProfile = "Home_CDN", VaryByParam = "None")]
        public ActionResult Css()
        {
            View("Index").ExecuteResult(ControllerContext);
            Response.Clear();
            string css = Bundle.Css().RenderCached("cssCache");
            Response.Cache.SetCacheability(HttpCacheability.Public);
            Response.Cache.SetOmitVaryStar(true);
            return Content(css, "text/css");
        }

        //[OutputCache(CacheProfile = "Home_CDN", VaryByParam = "None")]
        public ActionResult Js()
        {
            View("Index").ExecuteResult(ControllerContext);
            Response.Clear();
            Response.Cache.SetCacheability(HttpCacheability.Public);
            Response.Cache.SetOmitVaryStar(true);
            return Content(Bundle.JavaScript().RenderCached("jsCache"), "text/javascript");
        }
    }
}

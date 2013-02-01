using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epic.Controllers
{
    public class TestController : Controller
    {
        public ActionResult ViewTest(string id)
        {
            return View(id);
        }
    }
}

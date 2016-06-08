using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razzle.Controllers
{
    public class PlayerLoginController : Controller
    {
        public ActionResult PlayerOne()
        {
            ViewBag.Title = "PlayerOne Page";

            return View();
        }
        public ActionResult Foo()
        {
            ViewBag.Title = "Foo Page";

            return View();
        }
    }
}

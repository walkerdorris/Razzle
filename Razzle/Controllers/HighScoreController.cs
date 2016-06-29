using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razzle.Controllers
{
    public class HighScoreController : Controller
    {
        // GET: HighScore
        public ActionResult HighScore()
        {
            return View("HighScore");
        }
    }
}
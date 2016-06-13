using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razzle.Controllers
{
    public class GameController : Controller
    {
        // GET: MVCGame
        public ActionResult Game()
        {
            return View("Game");
        }
    }
}
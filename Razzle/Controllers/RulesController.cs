﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razzle.Controllers
{
    public class RulesController : Controller
    {
        // GET: Rules
        public ActionResult Rules()
        {
            return View("Rules");
        }
    }
}
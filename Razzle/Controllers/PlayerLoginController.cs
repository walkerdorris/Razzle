using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razzle.Controllers
{
    public class PlayerLoginController : Controller
    {
        //GET Player
        public ActionResult PlayerOne()
        {
            return View("PlayerOne");
        }

        //GET Player/Details
        public ActionResult Details(int id)
        {
            return View();
        }

        //GET Player/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST Player/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //ADD INSERT LOGIC

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}

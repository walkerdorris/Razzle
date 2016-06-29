using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Razzle.DAL;
using Razzle.Models;
using System.Web.Mvc;

namespace Razzle.Controllers
{
    public class GamesController : ApiController
    {
        // GET: api/Games/5
        [ResponseType(typeof(GameViewModel))]
        public GameViewModel GetGame(string p1, string p2)
        {
            var game = new GameViewModel(p1, p2);
            return game;
        }
    }
}
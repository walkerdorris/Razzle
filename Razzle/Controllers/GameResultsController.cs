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

namespace Razzle.Controllers
{
    public class GameResultsController : ApiController
    {
        private RazzleContext db = new RazzleContext();

        // GET: api/GameResults
        public IQueryable<GameResult> GetGameResults()
        {
            return db.GameResults;
        }

        // GET: api/GameResults/5
        [ResponseType(typeof(GameResult))]
        public IHttpActionResult GetGameResult(int id)
        {
            GameResult gameResult = db.GameResults.Find(id);
            if (gameResult == null)
            {
                return NotFound();
            }

            return Ok(gameResult);
        }

        // PUT: api/GameResults/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGameResult(int id, GameResult gameResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gameResult.GameResultId)
            {
                return BadRequest();
            }

            db.Entry(gameResult).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameResultExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GameResults
        [ResponseType(typeof(GameResult))]
        public IHttpActionResult PostGameResult(GameResult[] gameResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GameResults.Add(gameResult[0]);
            db.GameResults.Add(gameResult[1]);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.Accepted);
            //return CreatedAtRoute("DefaultApi", new { id = gameResult.GameResultId }, gameResult);
        }

        // DELETE: api/GameResults/5
        [ResponseType(typeof(GameResult))]
        public IHttpActionResult DeleteGameResult(int id)
        {
            GameResult gameResult = db.GameResults.Find(id);
            if (gameResult == null)
            {
                return NotFound();
            }

            db.GameResults.Remove(gameResult);
            db.SaveChanges();

            return Ok(gameResult);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameResultExists(int id)
        {
            return db.GameResults.Count(e => e.GameResultId == id) > 0;
        }
    }
}
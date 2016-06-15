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
    public class HighScores : ApiController
    {
        private RazzleContext db = new RazzleContext();

        // GET: api/HighScores
        public IQueryable<Turn> GetTurns()
        {
            return db.Turns;
        }

        // GET: api/HighScores/5
        [ResponseType(typeof(Turn))]
        public IHttpActionResult GetTurn(int id)
        {
            Turn turn = db.Turns.Find(id);
            if (turn == null)
            {
                return NotFound();
            }

            return Ok(turn);
        }

        // PUT: api/HighScores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTurn(int id, Turn turn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turn.TurnId)
            {
                return BadRequest();
            }

            db.Entry(turn).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurnExists(id))
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

        // POST: api/HighScores
        [ResponseType(typeof(Turn))]
        public IHttpActionResult PostTurn(Turn turn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Turns.Add(turn);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = turn.TurnId }, turn);
        }

        // DELETE: api/HighScores/5
        [ResponseType(typeof(Turn))]
        public IHttpActionResult DeleteTurn(int id)
        {
            Turn turn = db.Turns.Find(id);
            if (turn == null)
            {
                return NotFound();
            }

            db.Turns.Remove(turn);
            db.SaveChanges();

            return Ok(turn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurnExists(int id)
        {
            return db.Turns.Count(e => e.TurnId == id) > 0;
        }
    }
}
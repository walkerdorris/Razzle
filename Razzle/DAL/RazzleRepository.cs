using Razzle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Razzle.DAL
{
    public class RazzleRepository
    {
        public RazzleContext context { get; set; }

        public RazzleRepository()
        {
            //Needing an instance of Context
            context = new RazzleContext();
        }

        public RazzleRepository(RazzleContext _context)
        {
            //This allows us to inject a Context into our Repository
            context = _context;
        }

        public int GetGameResultCount()
        {
            return context.GameResults.Count();
        }

        public List<GameResult> GetGameResults()
        {
            return context.GameResults.ToList<GameResult>();
        }


        public void AddPlayerToGameResult(string _player)
        {
            GameResult new_player = new GameResult { Player = _player };
            context.GameResults.Add(new_player);
            context.SaveChanges();
        }

        public void AddPointsToGameResult(int _points)
        {
            GameResult new_points = new GameResult { Points = _points };
            context.GameResults.Add(new_points);
            context.SaveChanges();
        }

        public GameResult GetGameResult (int _gameresult_id)
        {
            //return context.GameResults.Find(_gameresult_id); //Requires explicit mocking of the DbSet.Find method
            GameResult gameresult;
            try
            {
                gameresult = context.GameResults.First(i => i.GameResultId == _gameresult_id);
            }
            catch (Exception)
            {
                throw new NotFoundException();
            }
            return gameresult;// ConnectMockstoDatastore made this possible
        }

        public void RemoveGameResult(int _gameresult_id)
        {
            GameResult some_gameresult = context.GameResults.First(i => i.GameResultId == _gameresult_id);

            context.GameResults.Remove(some_gameresult);
            context.SaveChanges();
        }

        public GameResult GetGameResultOrNull(int _gameresult_id)
        {
            return context.GameResults.FirstOrDefault(i => i.GameResultId == _gameresult_id);
        }

        //Create a GameResult

        //Delete a GameResult
    }
}
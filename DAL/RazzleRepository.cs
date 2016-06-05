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

        public int GetPlayerCount()
        {
            return context.Players.Count();
        }

        public int GetTurnCount()
        {
            return context.Turns.Count();
        }

        public int GetGameCount()
        {
            return context.Turns.Count();
        }

        public List<Player> GetPlayers()
        {
            return context.Players.ToList<Player>();
        }

        public List<Turn> GetTurns()
        {
            return context.Turns.ToList<Turn>();
        }

        public List<Game> GetGames()
        {
            return context.Games.ToList<Game>();
        }

        public void AddPlayer(string player_name)
        {
            throw new NotImplementedException();
        }
    }
}
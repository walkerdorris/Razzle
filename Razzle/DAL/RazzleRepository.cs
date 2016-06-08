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
            Player new_player = new Player { PlayerName = player_name };
            context.Players.Add(new_player);
            context.SaveChanges();
        }

        public Player GetPlayer(int _player_id)
        {
            //return context.Players.Find(_player_id); //Requires explicit mocking of the DbSet.Find method
            Player player;
            try
            {
                player = context.Players.First(i => i.PlayerID == _player_id);
            } catch (Exception)
            {
                throw new NotFoundException();
            }
            return player;// ConnectMockstoDatastore made this possible
        }

        public void RemovePlayer(int _player_id)
        {
            Player some_player = context.Players.First(i => i.PlayerID == _player_id);

            context.Players.Remove(some_player);
            context.SaveChanges();
        }

        public Player GetPlayerOrNull(int _player_id)
        {
            return context.Players.FirstOrDefault(i => i.PlayerID == _player_id);
        }

        //Create a Player

        //Delete a Player
    }
}
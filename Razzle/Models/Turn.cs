using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Razzle.Models
{
    public class Turn
    {
        public int TurnId { get; set; }

        //Foreign Key for Game - GameId
        public virtual Game Game { get; set; }

        //Foreign Key for Player - PlayerId; PlayerName
        public virtual Player Player { get; set; }

        //public int RoundId { get; set; }
        //public string BoardLayout { get; set; } 
        public int Points { get; set; }
        public string Word { get; set; }

        

    }
}
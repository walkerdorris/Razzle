using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Razzle.Models
{
    public class Game
    {
        public int GameId { get; set; }

        public virtual ICollection<Turn> Turn { get; set; }

    }
}
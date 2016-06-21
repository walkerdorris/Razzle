using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Razzle.Models
{
    public class MasterGame
    {
        public int MasterGameId { get; set; }
        public string Players { get; set; }
        public string[] BestWords { get; set; }
        public int[] Points { get; set; }

    }
}
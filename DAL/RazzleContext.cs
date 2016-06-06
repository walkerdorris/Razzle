using Razzle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Razzle.DAL
{
    public class RazzleContext: DbContext
    {
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Turn> Turns { get; set; }
        public virtual DbSet<Game> Games { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Razzle.Models
{
    public class Player
    {
        public int PlayerID { get; set; }

        [Required]
        public string PlayerName { get; set; }

        public virtual ICollection<Turn> Turn { get; set; }
    }
}
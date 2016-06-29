using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Razzle.Models
{
    public class GameResult
    {
        public int GameResultId { get; set; }

        [Required]
        public string Player { get; set; }

        [Required]
        public int Points { get; set; }

    }
}
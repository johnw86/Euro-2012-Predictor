using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FootballPredictor.Models
{
    public class Score
    {
        public Score()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public virtual Fixture Fixture { get; set; }
        public virtual User User { get; set; }
    }
}
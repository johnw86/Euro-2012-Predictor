using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FootballPredictor.Models
{
    public class Competition
    {
        public Competition()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        
    }
}
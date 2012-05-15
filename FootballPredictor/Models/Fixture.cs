using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FootballPredictor.Models
{
    public class Fixture
    {
        public Fixture()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public virtual Group Group { get; set; }
        public virtual Team Home { get; set; }
        public virtual Team Away { get; set; }


    }
}
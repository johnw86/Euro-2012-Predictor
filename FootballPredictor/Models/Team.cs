using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FootballPredictor.Models
{
    public class Team
    {
        public Team()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Fixture> Fixtures { get; set; }
    }
}
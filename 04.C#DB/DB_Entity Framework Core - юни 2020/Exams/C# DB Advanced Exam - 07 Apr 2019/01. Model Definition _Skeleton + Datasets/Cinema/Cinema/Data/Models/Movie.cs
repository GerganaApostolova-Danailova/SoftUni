using Cinema.Data.Models.Enums;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Projections = new HashSet<Projection>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [Range(1,10)]
        public double Rating { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Director { get; set; }

        public virtual ICollection<Projection> Projections { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        public Writer()
        {
            this.Songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Name { get; set; }

        [RegularExpression("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+")]
        public string Pseudonym { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}

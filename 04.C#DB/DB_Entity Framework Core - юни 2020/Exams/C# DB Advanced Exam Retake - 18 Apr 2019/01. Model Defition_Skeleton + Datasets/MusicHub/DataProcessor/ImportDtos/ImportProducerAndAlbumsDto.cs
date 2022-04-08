using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportProducerAndAlbumsDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }

        [RegularExpression("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^\+359 \d{3} \d{3} \d{3}$")]
        public string PhoneNumber { get; set; }

        [JsonProperty("Albums")]
        public ImportAlbumsDto[] Albums { get; set; }

    }
    public class ImportAlbumsDto
    {
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }
    }
}

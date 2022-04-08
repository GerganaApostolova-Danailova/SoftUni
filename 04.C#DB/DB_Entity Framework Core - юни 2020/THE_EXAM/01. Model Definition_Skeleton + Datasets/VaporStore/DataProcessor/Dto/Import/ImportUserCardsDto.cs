using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserCardsDto
    {
        [Required]
        [RegularExpression("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+")]
        public string FullName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(typeof(int), "3", "103")]
        public int Age { get; set; }

        public ImputCartDto[] Cards { get; set; }
    }

    public class ImputCartDto
    {
        [Required]
        [RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^(\d{3}){1}$")]
        [JsonProperty("CVC")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }
}

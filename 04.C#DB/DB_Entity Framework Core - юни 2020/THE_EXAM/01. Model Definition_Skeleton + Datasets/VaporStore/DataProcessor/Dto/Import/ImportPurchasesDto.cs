using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchasesDto
    {
        [XmlAttribute("title")]
        public string Titel { get; set; }

        [Required]
        [XmlElement("Type")]
        public string Type { get; set; }

        [Required]
        [RegularExpression(@"^([A-Z\d]{4})-([A-Z\d]{4})-([A-Z\d]{4})$")]
        [XmlElement("Key")]
        public string Key { get; set; }

        [Required]
        [RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$")]
        [XmlElement("Card")]

        public string Card { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }
    }
}

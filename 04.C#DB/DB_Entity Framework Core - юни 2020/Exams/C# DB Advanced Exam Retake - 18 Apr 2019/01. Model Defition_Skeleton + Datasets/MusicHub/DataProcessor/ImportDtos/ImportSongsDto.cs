using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Song")]
    public class ImportSongsDto
    {
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }

        [Required]
        [XmlElement("CreatedOn")]
        public string CreatedOn { get; set; }

        [Required]
        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("AlbumId")]
        public int? AlbumId { get; set; }

        [Required]
        [XmlElement("WriterId")]
        public int WriterId { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
  //  <Book>
  //  <Name>Hairy Torchwood</Name>
  //  <Genre>3</Genre>
  //  <Price>41.99</Price>
  //  <Pages>3013</Pages>
  //  <PublishedOn>01/13/2013</PublishedOn>
  //</Book>
   
    [XmlType("Book")]
    public class ImportBookDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [Range(1,3)]
        [XmlElement("Genre")]
        public int Genre { get; set; }

        [XmlElement("Price")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Range(50, 5000)]
        [XmlElement("Pages")]

        public int Pages { get; set; }

        [Required]
        [XmlElement("PublishedOn")]
        public string PublishedOn { get; set; }
    }
}

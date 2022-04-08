using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ExportDto
{
  //  <Book Pages = "4881" >
  //  < Name > Sierra Marsh Fern</Name>
  //     <Date>03/18/2016</Date>
  //</Book>

    [XmlType("Book")]
    public class ExportBookDto
    {
        [XmlAttribute("Pages")]
        public int Pages { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }
    }
}

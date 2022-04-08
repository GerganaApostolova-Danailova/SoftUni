using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.NewFolder.Export
{
  //  <car make = "Opel" model="Astra" travelled-distance="516628215">
  //  <parts>
  //    <part name = "Master cylinder" price="130.99" />
  //    <part name = "Water tank" price="100.99" />
  //    <part name = "Front Right Side Inner door handle" price="100.99" />
  //  </parts>
  //</car>

    [XmlType("car")]
    public class ExportCarsWhitPartsDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public List<CarPartsDto> Parts { get; set; }
    }

    [XmlType("part")]
    public class CarPartsDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}

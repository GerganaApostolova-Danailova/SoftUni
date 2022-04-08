using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.NewFolder.Import
{
    //  <Car>
    //  <make>Opel</make>
    //  <model>Omega</model>
    //  <TraveledDistance>176664996</TraveledDistance>
    //  <parts>
    //    <partId id = "38" />
    //    <partId id="102"/>
    //  </ parts >
    //</ Car >

    [XmlType("Car")]
    public class CarDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public PartCarDTO[] Parts { get; set; }
    }

    [XmlType("partId")]
    public class PartCarDTO
    {
        [XmlAttribute("id")]
        public int partId { get; set; }
    }
}

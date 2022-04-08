using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.NewFolder.Export
{
//    <cars>
//  <car id = "7" model="1M Coupe" travelled-distance="39826890" />
//  <car id = "16" model="E67" travelled-distance="476830509" />
//  <car id = "5" model="E88" travelled-distance="27453411" />
//    </cars>

    [XmlType("car")]
    public class ExportBMWCarDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}

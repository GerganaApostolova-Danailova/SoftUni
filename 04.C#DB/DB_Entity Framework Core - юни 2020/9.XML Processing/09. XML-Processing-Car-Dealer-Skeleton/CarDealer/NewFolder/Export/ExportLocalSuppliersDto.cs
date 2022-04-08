using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.NewFolder.Export
{
    //    suppliers>
    //  <suplier id = "2" name="VF Corporation" parts-count="3" />
    //  <suplier id = "5" name="Saks Inc" parts-count="2" />
    //  ...
    //</suppliers>

    [XmlType("suplier")]
    public class ExportLocalSuppliersDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }
    }
}

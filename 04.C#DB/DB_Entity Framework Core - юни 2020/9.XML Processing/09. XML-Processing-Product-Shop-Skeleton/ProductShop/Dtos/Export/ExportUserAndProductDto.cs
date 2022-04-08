using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    //<count>54</count>
    //<users>
    //  <User>
    //    <firstName>Cathee</firstName>
    //    <lastName>Rallings</lastName>
    //    <age>33</age>
    //    <SoldProducts>
    //      <count>9</count>
    //      <products>
    //        <Product>
    //          <name>Fair Foundation SPF 15</name>
    //          <price>1394.24</price>
    //        </Product>
    //        <Product>
    //          <name>IOPE RETIGEN MOISTURE TWIN CAKE NO.21</name>
    //          <price>1257.71</price>
    //        </Product>

    public class ExportUserAndProductDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public List<ExportUsersDto> Users { get; set; }
    }

    [XmlType("User")]
    public class ExportUsersDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public ExportSoldProductDto SoldProducts { get; set; }

    }
    [XmlType("SoldProducts")]
    public class ExportSoldProductDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ExportProductDto[] Products { get; set; }

    }

    [XmlType("Product")]
    public class ExportProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }

}


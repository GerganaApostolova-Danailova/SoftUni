﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.NewFolder.Import
{
    
    [XmlType("Sale")]
    public class ImportSaleDto
    {
        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

    }
}

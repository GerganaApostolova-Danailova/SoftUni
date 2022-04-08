using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Customer")]
    public class ImportCustomerTicketsDto
    {
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [XmlElement("LastName")]

        public string LastName { get; set; }

        [Required]
        [Range(12, 110)]
        [XmlElement("Age")]

        public int Age { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [XmlElement("Balance")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public ImportTicketsDto[] Tickets { get; set; }
    }

    [XmlType("Ticket")]
    public class ImportTicketsDto
    {
        [Required]
        [XmlElement("ProjectionId")]
        public int ProjectionId { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}

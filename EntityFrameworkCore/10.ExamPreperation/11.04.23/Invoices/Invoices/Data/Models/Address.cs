using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Models
{
    public class Address
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string StreetName { get; set; }

        public int StreetNumber { get; set; }

        public string PostCode { get; set; }

        [MaxLength(15)]
        public string City { get; set; }

        [MaxLength(15)]
        public string Country { get; set; }

        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}

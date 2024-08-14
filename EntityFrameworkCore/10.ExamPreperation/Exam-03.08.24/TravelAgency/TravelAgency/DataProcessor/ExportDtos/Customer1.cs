using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DataProcessor.ExportDtos
{
    public class Customer1
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public Booking1[] Bookings { get; set; }    
    }
}

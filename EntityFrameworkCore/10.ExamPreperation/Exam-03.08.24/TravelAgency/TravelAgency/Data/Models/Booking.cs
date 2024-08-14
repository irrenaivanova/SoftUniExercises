using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime BookingDate { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public int TourPackageId  { get; set; }

        public virtual TourPackage TourPackage { get; set; }
    }
}

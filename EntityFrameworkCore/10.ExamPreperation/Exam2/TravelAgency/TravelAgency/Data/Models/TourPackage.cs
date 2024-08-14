using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data.Models
{
    public class TourPackage
    {
        public TourPackage()
        {
            Bookings = new HashSet<Booking>();
            TourPackagesGuides = new HashSet<TourPackageGuide>();
        }
        public int Id { get; set; }

        [MaxLength(40)]
        public string PackageName { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
    }
}

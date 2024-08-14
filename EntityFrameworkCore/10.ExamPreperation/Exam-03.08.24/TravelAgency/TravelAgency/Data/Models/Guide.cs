using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Data.Models.Enums;

namespace TravelAgency.Data.Models
{
    public class Guide
    {
        public Guide()
        {
            TourPackagesGuides = new HashSet<TourPackageGuide>();   
        }
        public int Id { get; set; }
       
        [MaxLength(60)]
        public string FullName { get; set; }

        public Language Language { get; set; }

        public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
    }
}

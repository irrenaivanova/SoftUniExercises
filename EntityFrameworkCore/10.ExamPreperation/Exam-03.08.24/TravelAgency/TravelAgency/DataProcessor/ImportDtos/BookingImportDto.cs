using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DataProcessor.ImportDtos
{
    public class BookingImportDto
    {
        [Required]
        [RegularExpression(@"[0-9]{4}-[0-9]{2}-[0-9]{2}")]
        public string BookingDate { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string TourPackageName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }
        public int Id { get; set; }

        [MaxLength(60)]
        public string FullName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(13)]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}

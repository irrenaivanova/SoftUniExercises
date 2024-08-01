using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.Data.Models
{
    public class User
    {
        public User()
        {
           Cards = new List<Card>();
        }
        public int Id { get; set; }
        [MaxLength(20)]
        public string 	Username  { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Card> Cards { get; set;}
    }
}

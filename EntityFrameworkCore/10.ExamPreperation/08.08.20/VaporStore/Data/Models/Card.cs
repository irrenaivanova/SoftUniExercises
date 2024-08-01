using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Card
    {
        public Card()
        {
            Purchases = new List<Purchase>();
        }

        public int Id { get; set; }

        //[RegularExpression(@"([\d]{4} ){3}[\d]{4}")]
        public string Number { get; set; }

        //[RegularExpression(@"[\d]{3}")]
        public string Cvc { get; set; }

        public CardType Type { get; set; }  

        public int UserId { get; set; } 
        public virtual User User { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; } 
    }
}

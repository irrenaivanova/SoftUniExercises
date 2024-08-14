using Invoices.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Models
{
    public class Product
    {
        public Product()
        {
             ProductsClients = new HashSet<ProductClient>();
        }
        public int Id { get; set; }
        
        [MaxLength(30)]
        public string  Name { get; set; }

        public decimal Price  { get; set; }

        public CategoryType CategoryType { get; set; }

        public virtual ICollection<ProductClient> ProductsClients { get; set; }
    }
}

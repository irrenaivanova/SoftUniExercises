using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.DataConstants;

namespace DeskMarket.Data.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();  
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxCategoryNameLength)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Product> Products { get; set; }
    }
}

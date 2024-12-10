using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.DataConstants;

namespace DeskMarket.Data.Models
{
    public class Product
    {
        public Product()
        {
            ProductClient = new HashSet<ProductClient>();   
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxProductNameLength)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxDescriptionNameLength)]
        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public string SellerId { get; set; } = string.Empty;
        public virtual IdentityUser Seller { get; set; } = null!;

        public DateTime AddedOn { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        public bool IsDeleted { get; set; } 

        public virtual ICollection<ProductClient> ProductClient { get; set; } = null!;


    }
}

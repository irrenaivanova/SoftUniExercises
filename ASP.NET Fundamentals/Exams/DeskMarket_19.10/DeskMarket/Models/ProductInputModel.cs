using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.DataConstants;

namespace DeskMarket.Models
{
    public class ProductInputModel
    {
        public int? Id { get; set; }
        public int? SellerId { get; set; }

        [Required]
        [MinLength(MinProductNameLength)]
        [MaxLength(MaxProductNameLength)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [Range(MinProductPrice,MaxProductPrice)]
        public decimal Price { get; set; }
       
        [Required]
        [MinLength(MinDescriptionNameLength)]
        [MaxLength(MaxDescriptionNameLength)]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set;}
        
        [Required]
        public string AddedOn { get; set; } = string.Empty;
        
        [Required]
        public int CategoryId { get; set; }

        public ICollection<CategoryInput> Categories { get; set; } = new HashSet<CategoryInput>();
    }
}

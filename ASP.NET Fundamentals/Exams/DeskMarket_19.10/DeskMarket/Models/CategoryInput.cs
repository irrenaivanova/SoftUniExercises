using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.DataConstants;

namespace DeskMarket.Models
{
    public class CategoryInput
    {
        public int Id { get; set; }

        [Required]
        [MinLength(MinCategoryNameLength)]
        [MaxLength(MaxCategoryNameLength)]
        public string Name { get; set; } = string.Empty;
    }
}

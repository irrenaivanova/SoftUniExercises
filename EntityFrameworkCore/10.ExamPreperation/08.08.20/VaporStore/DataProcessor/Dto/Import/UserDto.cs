using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserDto
    {
        [Required]
        [RegularExpression(@"^[A-Z][a-z]{2,} [A-Z][a-z]{2,}$")]
        public string FullName { get; set; }
       
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(3,103)]
        public int Age { get; set; }
        public CardDto[] Cards { get; set; }

    }
}

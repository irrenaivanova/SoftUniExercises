﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class CardDto
    {
        [Required]
        [RegularExpression(@"([\d]{4} ){3}[\d]{4}")]
        public string Number { get; set; }
        
        [Required]
        [RegularExpression(@"[\d]{3}")]
        public string CVC { get; set; }
       
        [Required]
        public CardType? Type { get; set; }
    }
}


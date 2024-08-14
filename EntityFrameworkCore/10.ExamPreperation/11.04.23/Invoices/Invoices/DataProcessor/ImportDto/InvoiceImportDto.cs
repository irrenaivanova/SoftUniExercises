using Invoices.Data.Models.Enums;
using Invoices.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto
{
    public class InvoiceImportDto
    {
        [Required]
        [Range(1000000000, 1500000000)]
        public int Number { get; set; }
       
        [Required]
        public DateTime? IssueDate { get; set; }
       
        [Required]
        public DateTime? DueDate { get; set; }
        
        [Range(0,double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [Range(0, 2)]
        public int  CurrencyType { get; set; }
       
        [Required]
        public int ClientId { get; set; }

    }
}

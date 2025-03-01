﻿using Invoices.Data.Models.Enums;
using Invoices.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Invoice")]
    public class Invoice1
    {
        public int InvoiceNumber { get; set; }

        public decimal InvoiceAmount { get; set; }

        public string DueDate { get; set; }

        public string Currency { get; set; }

    }
}

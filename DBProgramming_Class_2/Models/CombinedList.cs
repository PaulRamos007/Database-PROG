using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBProgramming_Class_2.Models
{
    public class CombinedList
    {
        public List<Product> Products { get; set; }
        public Invoice Invoices { get; set; }
        public InvoiceLineItem Lines { get; set; }
        public List<Customer> Customers { get; set; }
        public List<InvoiceLineItem> InvoiceLines { get; set; }
    }
}
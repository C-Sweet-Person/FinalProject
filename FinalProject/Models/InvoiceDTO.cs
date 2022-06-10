using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class InvoiceDTO
    {
        public Invoice Invoice { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
    }
}
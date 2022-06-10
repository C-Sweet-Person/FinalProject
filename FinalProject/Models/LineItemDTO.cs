using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class LineItemDTO
    {
        public InvoiceLineItem LineItem { get; set; }
        public List<Product> Products { get; set; }
    }
}
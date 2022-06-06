using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
namespace FinalProject.Controllers
{
    /*
     * switch (sortBy)
            {
                case 1:
                    {
                allInvoices = context.Invoices.OrderBy(c => c.InvoiceID).ToList();
                        break;
                    }
                case 2:
                    {
                allInvoices = context.Invoices.OrderBy(c => c.Name).ToList();
                        break;
                    }
                case 3:
                    {
                allInvoices = context.Invoices.OrderBy(c => c.Address).ToList();
                        break;
                    }
            case 4:
                    {
                allInvoices = context.Invoices.OrderBy(c => c.City).ToList();
                        break;
                    }

    */
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult All(string id, int sortBy = 0)
        {
            BooksEntities context = new BooksEntities();
            List<Invoice> allInvoices = context.Invoices.ToList<Invoice>();
            switch (sortBy)
            {
                case 0:
                    {
                        allInvoices = context.Invoices.OrderBy(i => i.InvoiceID).ToList();
                        break;
                    }
                case 1:
                    {
                        allInvoices = context.Invoices.OrderBy(i => i.CustomerID).ToList();
                        break;
                    }
                case 2:
                    {
                        allInvoices = context.Invoices.OrderBy(i => i.InvoiceDate).ToList();
                        break;
                    }
                case 3:
                    {
                        allInvoices = context.Invoices.OrderBy(i => i.ProductTotal).ToList();
                        break;
                    }
                case 4:
                    {
                        allInvoices = context.Invoices.OrderBy(i => i.SalesTax).ToList();
                        break;
                    }
                case 5:
                    {
                        allInvoices = context.Invoices.OrderBy(i => i.Shipping).ToList();
                        break;
                    }
                case 6:
                    {
                        allInvoices = context.Invoices.OrderBy(i => i.InvoiceTotal).ToList();
                        break;
                    }
                default:
                    {
                        allInvoices = context.Invoices.OrderBy(i => i.InvoiceID).ToList();
                        break;
                    }
            }
                    return View(allInvoices);
        }
    }
}
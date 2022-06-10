using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using System.Data.Entity.Migrations;

namespace FinalProject.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult All(string id, int sortBy = 0)
        {
            Entities context = new Entities();
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
                case 7:
                    {
                        allInvoices = context.Invoices.OrderBy(i => i.InvoiceLineItems.Count).ToList();
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">This is the ID of the invoice.</param>
        /// <returns>The view to the website.</returns>
        [HttpGet]
        public ActionResult Upsert(int id = 0)
        {
            Entities context = new Entities();
            Invoice newInvoice = context.Invoices.Where(i => i.InvoiceID == id).FirstOrDefault();
            if (newInvoice == null)
            {
                newInvoice = new Invoice();
                newInvoice.Customer = new Customer();
            }
            InvoiceDTO dto = new InvoiceDTO()
            {
                Invoice = newInvoice,
                Customers = context.Customers.ToList(),
                Products = context.Products.ToList()
            };
            return View(dto);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceModel">This is the invoice DTO model.</param>
        /// <param name="customerId">Customer ID that is a string then it's converted to an int.</param>
        /// <returns>Redirects back to main page.</returns>
        [HttpPost]
        public ActionResult Upsert(InvoiceDTO invoiceModel, string customerId)
        {
            Entities context = new Entities();
            int iCustomerID = Convert.ToInt32(customerId.Split('-')[0].Trim());
            invoiceModel.Invoice.CustomerID = iCustomerID;
            Invoice invoiceToUpdate = CalculateInvoiceTotals(invoiceModel.Invoice);
            try
            {
                context.Invoices.AddOrUpdate(invoiceModel.Invoice);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            context.SaveChanges();
            return RedirectToAction("All");
        }
        /// <summary>
        /// This method calculates the invoice totals using a foreach loop.
        /// </summary>
        /// <param name="invoice">This is used to grab an invoice.</param>
        /// <returns>An invoice.</returns>
        public Invoice CalculateInvoiceTotals(Invoice invoice)
        {
            Entities context = new Entities();

            List<InvoiceLineItem> lineItems = context.InvoiceLineItems.Where(i => i.InvoiceID == invoice.InvoiceID).ToList();

            invoice.InvoiceTotal = 0;
            invoice.ProductTotal = 0;
            foreach (var lineItem in lineItems)
            {
                invoice.ProductTotal = invoice.ProductTotal + lineItem.ItemTotal;
            }
            invoice.InvoiceTotal = invoice.ProductTotal + invoice.Shipping + invoice.SalesTax;

            return invoice;
        }
    }
}
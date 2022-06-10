using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using System.Data.Entity.Migrations;

namespace FinalProject.Controllers
{
    public class InvoiceLineItemsController : Controller
    {
        /// <summary>
        /// This grabs the line item from the url.
        /// </summary>
        /// <param name="invoiceId">InvoiceID for the line item.</param>
        /// <param name="productCode">productCode for the line item.</param>
        /// <returns>The line Item and puts it on the page.</returns>
        [HttpGet]
        public ActionResult Upsert(int invoiceId, string productCode)
        {
            Entities context = new Entities();

            InvoiceLineItem lineItem = context.InvoiceLineItems.Where(i => i.InvoiceID == invoiceId && i.ProductCode == productCode).FirstOrDefault();
            if (lineItem == null)
            {
                lineItem = new InvoiceLineItem();
                lineItem.InvoiceID = invoiceId;
            }

            List<Product> newProducts = context.Products.ToList();
            LineItemDTO UC = new LineItemDTO()
            {
                LineItem = lineItem,
                Products = newProducts
            };
            return View(UC);
        }
        /// <summary>
        /// This method is used to post a LineItem to the invoice.
        /// 
        /// </summary>
        /// <param name="lineItem">The line item itself.</param>
        /// <returns>Back to the invoice page.</returns>
        [HttpPost]
        public ActionResult Upsert(LineItemDTO model, string ProductCode)
        {
            InvoiceLineItem lineItem = model.LineItem;
            lineItem.ProductCode = ProductCode.Trim();
            Entities context = new Entities();
            try
            {
                lineItem.ItemTotal = lineItem.Quantity * lineItem.UnitPrice; 
                context.InvoiceLineItems.AddOrUpdate(lineItem);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Redirect("/Invoice/Upsert/" + lineItem.InvoiceID.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class ProductController : Controller
    {
        //** TODO: Add a buy button interface.
        // GET: Product
        public ActionResult All()
        {
            BooksEntities context = new BooksEntities();
            List<Product> allProducts = new List<Product>();
            allProducts = context.Products.ToList<Product>();
            return View(allProducts);
        }
        //        public ActionResult Buy()
        //        {

        //            return View();
        //        }
        //        [HttpPost]
        //        public ActionResult Buy(Invoice model)
        //        {
        //            Customer newInvoice = model;
        //            TechSupportEntities1 context = new TechSupportEntities1();
        //            try
        //            {
        //                if (context.Customers.Where(s => s.CustomerID == newCustomer.CustomerID).Count() > 0)
        //                {
        //                    var customerToSave = context.Customers.Where(s => s.CustomerID == newCustomer.CustomerID).FirstOrDefault();
        //                    customerToSave.City = newCustomer.City;
        //                    customerToSave.Email = newCustomer.Email;
        //                    customerToSave.Name = newCustomer.Name;
        //                    customerToSave.Phone = newCustomer.Phone;
        //                    customerToSave.Address = newCustomer.Address;
        //                    customerToSave.ZipCode = newCustomer.ZipCode;
        //                    customerToSave.State = newCustomer.State;
        //                }
        //                else
        //                {
        //                    context.Invoice.Add(newCustomer);
        //                }
        //                context.SaveChanges();
        //            }
        //            catch (Exception ex)
        //            {
        //                RedirectToAction(ex.Message);
        //            }
        //            return RedirectToAction("Customers");
        //        }
        //    }
        //}
    }
}
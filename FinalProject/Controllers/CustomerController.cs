using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Database_Project_Deux.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult All(int sortBy = 0)
        {
            var context = new BooksEntities();
            List<Customer> allCustomers;
            allCustomers = context.Customers.ToList<Customer>();
            switch (sortBy)
            {
              
            }

            return View(allCustomers);
        }
        [HttpGet]
        public ActionResult Upsert(int id = 0)
        {
            BooksEntities context = new BooksEntities();
            Customer newCustomer = context.Customers.Where(p => p.CustomerID == id).FirstOrDefault();
            if (newCustomer == null)
            {
                newCustomer = new Customer();
            }
            
            List<State> newStates = context.States.ToList();

            UpsertCustomer UC = new UpsertCustomer()
            {
                customer = newCustomer,
                States = newStates,
            };
            return View(UC);
        }
        [HttpPost]
        public ActionResult Upsert(UpsertCustomer model)
        {
            Customer newCustomer = model.customer;
            BooksEntities context = new BooksEntities();
            try
            {
                if (context.Customers.Where(s => s.CustomerID == newCustomer.CustomerID).Count() > 0)
                {
                    var CustomerToSave = context.Customers.Where(s => s.CustomerID == newCustomer.CustomerID).FirstOrDefault();
                    CustomerToSave.Name = newCustomer.Name;
                    CustomerToSave.Address = newCustomer.Address;
                    CustomerToSave.City = newCustomer.City;
                    CustomerToSave.State = newCustomer.State;
                    CustomerToSave.ZipCode = newCustomer.ZipCode;

                }
                else
                {
                    context.Customers.Add(newCustomer);
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                RedirectToAction(ex.Message);
            }
            return RedirectToAction("All");
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
     
            return RedirectToAction("All");
        }
    }
}
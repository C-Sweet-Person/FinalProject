using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Database_Project_Deux.Controllers
{
    /// <summary>
    /// This method gets the customer from the HTTP
    /// </summary>
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult All(int sortBy = 0)
        {
            var context = new Entities();
            List<Customer> allCustomers;
            allCustomers = context.Customers.ToList<Customer>();
            switch (sortBy)
            {
                case 0:
                    {
                        allCustomers = context.Customers.OrderBy(i => i.CustomerID).ToList();
                        break;
                    }
                case 1:
                    {
                        allCustomers = context.Customers.OrderBy(i => i.Name).ToList();
                        break;
                    }
                case 2:
                    {
                        allCustomers = context.Customers.OrderBy(i => i.Address).ToList();
                        break;
                    }
                case 3:
                    {
                        allCustomers = context.Customers.OrderBy(i => i.City).ToList();
                        break;
                    }
                case 4:
                    {
                        allCustomers = context.Customers.OrderBy(i => i.State).ToList();
                        break;
                    }
                case 5:
                    {
                        allCustomers = context.Customers.OrderBy(i => i.ZipCode).ToList();
                        break;
                    }
                default:
                    {
                        allCustomers = context.Customers.OrderBy(i => i.CustomerID).ToList();
                        break;
                    }

            }

            return View(allCustomers);
        }
       /// <summary>
       /// This method is used for getting the customer info from the url and returning the view.
       /// </summary>
       /// <param name="id">CustomerID</param>
       /// <returns>The customer to the view.</returns>
        [HttpGet]
        public ActionResult Upsert(int id = 0)
        {
            Entities context = new Entities();
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
        /// <summary>
        /// This method is used to post the customer to the database.
        /// </summary>
        /// <param name="model">This is the upsert Customer model containing the lists.</param>
        /// <returns>The user back to the homepage..</returns>
        [HttpPost]
        public ActionResult Upsert(UpsertCustomer model)
        {
            Customer newCustomer = model.customer;
            Entities context = new Entities();
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
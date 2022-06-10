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
       
        public ActionResult All()
        {
            Entities context = new Entities();
            List<Product> allProducts = new List<Product>();
            allProducts = context.Products.ToList<Product>();
            return View(allProducts);
        }
        /// <summary>
        /// Is the get of the upsert.
        /// </summary>
        /// <param name="productCode">The productcode from the url.</param>
        /// <returns>The productCode object to the view.</returns>
        [HttpGet]
        public ActionResult Upsert(string productCode)
        {
            Entities context = new Entities();
            Product product = context.Products.Where(p => p.ProductCode == productCode).FirstOrDefault();
            if (product == null)
            {
                product = new Product();
                product.ProductCode = RandomWord(4);
            }

            return View(product);
        }
        /// <summary>
        /// This method posts the product to the table.
        /// </summary>
        /// <param name="model">The product model</param>
        /// <returns>Back to the main page of product.</returns>
        [HttpPost]
     
        public ActionResult Upsert(Product model)
        {
            Product newProduct = model;
            Entities context = new Entities();
            try
            {
                if (context.Products.Where(s => s.ProductCode == newProduct.ProductCode).Count() > 0)
                {
                    var ProductToSave = context.Products.Where(p => p.ProductCode == newProduct.ProductCode).FirstOrDefault();
                    ProductToSave.Description = newProduct.Description;
                    ProductToSave.UnitPrice = newProduct.UnitPrice;
                    ProductToSave.OnHandQuantity = newProduct.OnHandQuantity;

                }
                else
                {
                    context.Products.Add(newProduct);
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                RedirectToAction(ex.Message);
            }
            return RedirectToAction("All");
        }
        public string RandomWord(int count)
        {
            Random rnd = new Random();
            string letters = "";
            for(int i = 0; i < count; i++)
            {
                int ascii_index = rnd.Next(65, 91);
                char randomCase = Convert.ToChar(ascii_index);
                letters += randomCase;
            }
            return letters;
        }
    }
}
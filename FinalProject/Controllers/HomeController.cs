using Square;
using Square.Exceptions;
using Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            SquareClient client = new SquareClient.Builder()
    .Environment(Square.Environment.Sandbox)
    .AccessToken("EAAAEIzWTOKlSVHQV-a6vJX-Uys1sJ-neYYNviSbrQw5sfMF8QJZDLk-s6H_S9ii")
    .Build();
            var amountMoney = new Money.Builder()
  .Amount(290L)
  .Currency("CAD")
  .Build();

            var body = new CreatePaymentRequest.Builder(
                sourceId: "cnon:card-nonce-ok",
                idempotencyKey: Guid.NewGuid().ToString(),
                amountMoney: amountMoney)
              .Build();

            try
            {
                var result = client.PaymentsApi.CreatePayment(body: body);
            }
            catch (ApiException e)
            {
                Console.WriteLine("Failed to make the request");
                Console.WriteLine($"Response Code: {e.ResponseCode}");
                Console.WriteLine($"Exception: {e.Message}");
            }
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
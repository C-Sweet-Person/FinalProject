using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

    public class StateController : Controller
    {
        // GET: State
        public ActionResult All()
        {
        var context = new BooksEntities();
        List<State> Allstates = new List<State>();
        Allstates = context.States.ToList<State>();
            return View(Allstates);
        }
    }


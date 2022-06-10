using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using System.Data.Entity.Migrations;


public class StateController : Controller
    {
        // GET: State
        public ActionResult All(string id, int sortBy = 0)
        {
            Entities context = new Entities();
            List<State> allStates;
            switch (sortBy)
            {
                case 0:
                    {
                    allStates = context.States.OrderBy(i => i.StateName).ToList();
                        break;
                    }
                case 1:
                    {
                    allStates = context.States.OrderBy(i => i.StateCode).ToList();
                        break;
                    }
                default:
                    {
                    allStates = context.States.OrderBy(i => i.StateName).ToList();
                        break;
                    }
            }
            return View(allStates);
        }
    [HttpGet]
    public ActionResult Upsert(string id)
    {
        Entities context = new Entities();
        State newState = context.States.Where(p => p.StateCode == id).FirstOrDefault();
        if (newState == null)
        {
            newState = new State();
            newState.StateCode = "zz";
        }

        List<State> newStates = context.States.ToList();
        return View(newState);
    }
    [HttpPost]
    public ActionResult Upsert(State StateModel)
    {
        Entities context = new Entities();
        try
        {
            context.States.AddOrUpdate(StateModel);
        }
        catch (Exception ex)
        {

            throw ex;
        }
        context.SaveChanges();
        return RedirectToAction("All");
    }
}

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
        public ActionResult All()
        {
        var context = new Entities();
        List<State> Allstates = new List<State>();
        Allstates = context.States.ToList<State>();
            return View(Allstates);
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

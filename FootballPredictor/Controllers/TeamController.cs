using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballPredictor.Models;
using FootballPredictor;

namespace FootballPredictor.Controllers
{ 
    public class TeamController : Controller
    {
        private Repository db = new Repository();

        //
        // GET: /Team/

        public ViewResult Index()
        {
            return View(db.Teams.ToList());
        }

        //
        // GET: /Team/Details/5

        public ViewResult Details(Guid id)
        {
            Team team = db.Teams.Find(id);
            return View(team);
        }

        //
        // GET: /Team/Create

        public ActionResult Create()
        {
            ViewData["Groups"] = db.Groups;
            return View();
        } 

        //
        // POST: /Team/Create

        [HttpPost]
        public ActionResult Create(Team team, Guid GroupId)
        {
            if (ModelState.IsValid)
            {
                team.Id = Guid.NewGuid();

                var group = db.Groups.Find(GroupId);
                group.Teams.Add(team);

                db.Teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(team);
        }
        
        //
        // GET: /Team/Edit/5
 
        public ActionResult Edit(Guid id)
        {
            Team team = db.Teams.Find(id);
            return View(team);
        }

        //
        // POST: /Team/Edit/5

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        //
        // GET: /Team/Delete/5
 
        public ActionResult Delete(Guid id)
        {
            Team team = db.Teams.Find(id);
            return View(team);
        }

        //
        // POST: /Team/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {            
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
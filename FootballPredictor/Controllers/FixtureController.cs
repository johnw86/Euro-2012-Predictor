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
    public class FixtureController : Controller
    {
        private Repository db = new Repository();

        //
        // GET: /Fixture/

        public ViewResult Index()
        {
            return View(db.Fixtures.ToList());
        }

        //
        // GET: /Fixture/Details/5

        public ViewResult Details(Guid id)
        {
            Fixture fixture = db.Fixtures.Find(id);
            return View(fixture);
        }

        //
        // GET: /Fixture/Create

        public ActionResult Create()
        {
            ViewBag.Teams = db.Teams;
            ViewBag.Groups = db.Groups;
            return View();
        } 

        //
        // POST: /Fixture/Create

        [HttpPost]
        public ActionResult Create(Fixture fixture, Guid GroupId, Guid HomeTeamId, Guid AwayTeamId)
        {
            if (ModelState.IsValid)
            {
                var group = db.Groups.Find(GroupId);
                var homeTeam = db.Teams.Find(HomeTeamId);
                var awayTeam = db.Teams.Find(AwayTeamId);

                fixture.Id = Guid.NewGuid();
                fixture.Away = awayTeam;
                fixture.Home = homeTeam;
                fixture.Group = group;

                db.Fixtures.Add(fixture);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(fixture);
        }
        
        //
        // GET: /Fixture/Edit/5
 
        public ActionResult Edit(Guid id)
        {
            Fixture fixture = db.Fixtures.Find(id);
            return View(fixture);
        }

        //
        // POST: /Fixture/Edit/5

        [HttpPost]
        public ActionResult Edit(Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fixture);
        }

        //
        // GET: /Fixture/Delete/5
 
        public ActionResult Delete(Guid id)
        {
            Fixture fixture = db.Fixtures.Find(id);
            return View(fixture);
        }

        //
        // POST: /Fixture/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {            
            Fixture fixture = db.Fixtures.Find(id);
            db.Fixtures.Remove(fixture);
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
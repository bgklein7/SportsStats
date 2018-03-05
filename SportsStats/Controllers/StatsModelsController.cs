using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SportsStats.Models;

namespace SportsStats.Controllers
{
    public class StatsModelsController : Controller
    {
        private SportsStatsContext db = new SportsStatsContext();

        // GET: StatsModels
        public ActionResult Index()
        {
            return View(db.StatsModels.ToList());
        }

        // GET: StatsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatsModel statsModel = db.StatsModels.Find(id);
            if (statsModel == null)
            {
                return HttpNotFound();
            }
            return View(statsModel);
        }

        // GET: StatsModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatID,StatType,StatValue,StatYear,StatDesc")] StatsModel statsModel)
        {
            if (ModelState.IsValid)
            {
                db.StatsModels.Add(statsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statsModel);
        }

        // GET: StatsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatsModel statsModel = db.StatsModels.Find(id);
            if (statsModel == null)
            {
                return HttpNotFound();
            }
            return View(statsModel);
        }

        // POST: StatsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatID,StatType,StatValue,StatYear,StatDesc")] StatsModel statsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statsModel);
        }

        // GET: StatsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatsModel statsModel = db.StatsModels.Find(id);
            if (statsModel == null)
            {
                return HttpNotFound();
            }
            return View(statsModel);
        }

        // POST: StatsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatsModel statsModel = db.StatsModels.Find(id);
            db.StatsModels.Remove(statsModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

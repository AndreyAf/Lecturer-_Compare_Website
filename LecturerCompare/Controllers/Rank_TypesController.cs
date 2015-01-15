using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LecturerCompare.Models;

namespace LecturerCompare.Controllers
{
	[Authorize]
    public class Rank_TypesController : Controller
    {
        private LecDBEntities db = new LecDBEntities();

        // GET: Rank_Types
        public ActionResult Index()
        {
		ViewBag.Title = "change title";
            return View(db.Rank_Types.ToList());
        }

        // GET: Rank_Types/Details/5
        public ActionResult Details(int? id)
        {
			ViewBag.Title = "change title";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rank_Types rank_Types = db.Rank_Types.Find(id);
            if (rank_Types == null)
            {
                return HttpNotFound();
            }
            return View(rank_Types);
        }

        // GET: Rank_Types/Create
        public ActionResult Create()
        {
		ViewBag.Title = "change title";
            return View();
        }

        // POST: Rank_Types/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] Rank_Types rank_Types)
        {
		ViewBag.Title = "change title";
            if (ModelState.IsValid)
            {
                db.Rank_Types.Add(rank_Types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rank_Types);
        }

        // GET: Rank_Types/Edit/5
        public ActionResult Edit(int? id)
        {
		ViewBag.Title = "change title";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rank_Types rank_Types = db.Rank_Types.Find(id);
            if (rank_Types == null)
            {
                return HttpNotFound();
            }
            return View(rank_Types);
        }

        // POST: Rank_Types/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] Rank_Types rank_Types)
        {
		ViewBag.Title = "change title";
            if (ModelState.IsValid)
            {
                db.Entry(rank_Types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rank_Types);
        }

        // GET: Rank_Types/Delete/5
        public ActionResult Delete(int? id)
        {
		ViewBag.Title = "change title";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rank_Types rank_Types = db.Rank_Types.Find(id);
            if (rank_Types == null)
            {
                return HttpNotFound();
            }
            return View(rank_Types);
        }

        // POST: Rank_Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rank_Types rank_Types = db.Rank_Types.Find(id);
            db.Rank_Types.Remove(rank_Types);
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

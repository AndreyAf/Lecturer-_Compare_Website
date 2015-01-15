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
    public class SchoolsController : Controller
    {
        private LecDBEntities db = new LecDBEntities();

        // GET: Schools
        public ActionResult Index()
        {
		ViewBag.Title = "change title";
            return View(db.Schools.ToList());
        }

        // GET: Schools/Details/5
        public ActionResult Details(int? id)
        {
			ViewBag.Title = "change title";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schools schools = db.Schools.Find(id);
            if (schools == null)
            {
                return HttpNotFound();
            }
            return View(schools);
        }

        // GET: Schools/Create
        public ActionResult Create()
        {
		ViewBag.Title = "change title";
            return View();
        }

        // POST: Schools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] Schools schools)
        {
		ViewBag.Title = "change title";
            if (ModelState.IsValid)
            {
                db.Schools.Add(schools);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schools);
        }

        // GET: Schools/Edit/5
        public ActionResult Edit(int? id)
        {
		ViewBag.Title = "change title";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schools schools = db.Schools.Find(id);
            if (schools == null)
            {
                return HttpNotFound();
            }
            return View(schools);
        }

        // POST: Schools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] Schools schools)
        {
		ViewBag.Title = "change title";
            if (ModelState.IsValid)
            {
                db.Entry(schools).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schools);
        }

        // GET: Schools/Delete/5
        public ActionResult Delete(int? id)
        {
		ViewBag.Title = "change title";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schools schools = db.Schools.Find(id);
            if (schools == null)
            {
                return HttpNotFound();
            }
            return View(schools);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schools schools = db.Schools.Find(id);
            db.Schools.Remove(schools);
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

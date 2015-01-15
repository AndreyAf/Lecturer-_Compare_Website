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
    public class LecturersController : Controller
    {
        private LecDBEntities db = new LecDBEntities();

        // GET: Lecturers
        public ActionResult Index()
        {
		ViewBag.Title = "change title";
            var lecturers = db.Lecturers.Include(l => l.Lec_Rank);
            return View(lecturers.ToList());
        }

        // GET: Lecturers/Details/5
        public ActionResult Details(int? id)
        {
			ViewBag.Title = "change title";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturers lecturers = db.Lecturers.Find(id);
            if (lecturers == null)
            {
                return HttpNotFound();
            }
            return View(lecturers);
        }

        // GET: Lecturers/Create
        public ActionResult Create()
        {
		ViewBag.Title = "change title";
            ViewBag.Id = new SelectList(db.Lec_Rank, "Lec_Id", "Lec_Id");
            return View();
        }

        // POST: Lecturers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,Email,Image")] Lecturers lecturers)
        {
		ViewBag.Title = "change title";
            if (ModelState.IsValid)
            {
                db.Lecturers.Add(lecturers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Lec_Rank, "Lec_Id", "Lec_Id", lecturers.Id);
            return View(lecturers);
        }

        // GET: Lecturers/Edit/5
        public ActionResult Edit(int? id)
        {
		ViewBag.Title = "change title";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturers lecturers = db.Lecturers.Find(id);
            if (lecturers == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Lec_Rank, "Lec_Id", "Lec_Id", lecturers.Id);
            return View(lecturers);
        }

        // POST: Lecturers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,Email,Image")] Lecturers lecturers)
        {
		ViewBag.Title = "change title";
            if (ModelState.IsValid)
            {
                db.Entry(lecturers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Lec_Rank, "Lec_Id", "Lec_Id", lecturers.Id);
            return View(lecturers);
        }

        // GET: Lecturers/Delete/5
        public ActionResult Delete(int? id)
        {
		ViewBag.Title = "change title";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturers lecturers = db.Lecturers.Find(id);
            if (lecturers == null)
            {
                return HttpNotFound();
            }
            return View(lecturers);
        }

        // POST: Lecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lecturers lecturers = db.Lecturers.Find(id);
            db.Lecturers.Remove(lecturers);
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

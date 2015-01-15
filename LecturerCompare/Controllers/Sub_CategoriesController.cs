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
    public class Sub_CategoriesController : Controller
    {
        private LecDBEntities db = new LecDBEntities();

        // GET: Sub_Categories
        public ActionResult Index()
        {
		ViewBag.Title = "change title";
            var sub_Categories = db.Sub_Categories.Include(s => s.Categories);
            return View(sub_Categories.ToList());
        }

        // GET: Sub_Categories/Details/5
        public ActionResult Details(int? id)
        {
			ViewBag.Title = "change title";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Categories sub_Categories = db.Sub_Categories.Find(id);
            if (sub_Categories == null)
            {
                return HttpNotFound();
            }
            return View(sub_Categories);
        }

        // GET: Sub_Categories/Create
        public ActionResult Create()
        {
		ViewBag.Title = "change title";
            ViewBag.Cat_Id = new SelectList(db.Categories, "Id", "Title");
            return View();
        }

        // POST: Sub_Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cat_Id,Title")] Sub_Categories sub_Categories)
        {
		ViewBag.Title = "change title";
            if (ModelState.IsValid)
            {
                db.Sub_Categories.Add(sub_Categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cat_Id = new SelectList(db.Categories, "Id", "Title", sub_Categories.Cat_Id);
            return View(sub_Categories);
        }

        // GET: Sub_Categories/Edit/5
        public ActionResult Edit(int? id)
        {
		ViewBag.Title = "change title";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Categories sub_Categories = db.Sub_Categories.Find(id);
            if (sub_Categories == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cat_Id = new SelectList(db.Categories, "Id", "Title", sub_Categories.Cat_Id);
            return View(sub_Categories);
        }

        // POST: Sub_Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cat_Id,Title")] Sub_Categories sub_Categories)
        {
		ViewBag.Title = "change title";
            if (ModelState.IsValid)
            {
                db.Entry(sub_Categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cat_Id = new SelectList(db.Categories, "Id", "Title", sub_Categories.Cat_Id);
            return View(sub_Categories);
        }

        // GET: Sub_Categories/Delete/5
        public ActionResult Delete(int? id)
        {
		ViewBag.Title = "change title";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Categories sub_Categories = db.Sub_Categories.Find(id);
            if (sub_Categories == null)
            {
                return HttpNotFound();
            }
            return View(sub_Categories);
        }

        // POST: Sub_Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sub_Categories sub_Categories = db.Sub_Categories.Find(id);
            db.Sub_Categories.Remove(sub_Categories);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NegociosElectronicosII.Models;

namespace NegociosElectronicosII.Controllers
{
    public class CategoryController : Controller
    {
        private NE_Entity db = new NE_Entity();

        // GET: Category
        public ActionResult Index()
        {
            return View(db.NE_Category.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Category nE_Category = db.NE_Category.Find(id);
            if (nE_Category == null)
            {
                return HttpNotFound();
            }
            return View(nE_Category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Category,Category")] NE_Category nE_Category)
        {
            if (ModelState.IsValid)
            {
                db.NE_Category.Add(nE_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nE_Category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Category nE_Category = db.NE_Category.Find(id);
            if (nE_Category == null)
            {
                return HttpNotFound();
            }
            return View(nE_Category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Category,Category")] NE_Category nE_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nE_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nE_Category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Category nE_Category = db.NE_Category.Find(id);
            if (nE_Category == null)
            {
                return HttpNotFound();
            }
            return View(nE_Category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NE_Category nE_Category = db.NE_Category.Find(id);
            db.NE_Category.Remove(nE_Category);
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

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
    public class CarruselController : BaseController
    {
        private DB_NE_Entitties db = new DB_NE_Entitties();

        // GET: Carrusel
        public ActionResult Index()
        {
            return View(db.NE_Carrusel.ToList());
        }

        // GET: Carrusel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Carrusel nE_Carrusel = db.NE_Carrusel.Find(id);
            if (nE_Carrusel == null)
            {
                return HttpNotFound();
            }
            return View(nE_Carrusel);
        }

        // GET: Carrusel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carrusel/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarruselId,Posicion,Texto,Descripcion,Ruta,Extension,NombreArchivo,Activo")] NE_Carrusel nE_Carrusel)
        {
            if (ModelState.IsValid)
            {
                db.NE_Carrusel.Add(nE_Carrusel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nE_Carrusel);
        }

        // GET: Carrusel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Carrusel nE_Carrusel = db.NE_Carrusel.Find(id);
            if (nE_Carrusel == null)
            {
                return HttpNotFound();
            }
            return View(nE_Carrusel);
        }

        // POST: Carrusel/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarruselId,Posicion,Texto,Descripcion,Ruta,Extension,NombreArchivo,Activo")] NE_Carrusel nE_Carrusel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nE_Carrusel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nE_Carrusel);
        }

        // GET: Carrusel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Carrusel nE_Carrusel = db.NE_Carrusel.Find(id);
            if (nE_Carrusel == null)
            {
                return HttpNotFound();
            }
            return View(nE_Carrusel);
        }

        // POST: Carrusel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NE_Carrusel nE_Carrusel = db.NE_Carrusel.Find(id);
            db.NE_Carrusel.Remove(nE_Carrusel);
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

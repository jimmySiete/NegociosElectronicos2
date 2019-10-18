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
    public class VehiculoController : Controller
    {
        private DB_NE_Entitties db = new DB_NE_Entitties();

        // GET: Vehiculo
        public ActionResult Index()
        {
            var nE_Vehiculo = db.NE_Vehiculo.Include(n => n.NE_Categoria).Include(n => n.NE_Color).Include(n => n.NE_Marca).Include(n => n.NE_Transmision);
            return View(nE_Vehiculo.ToList());
        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Vehiculo nE_Vehiculo = db.NE_Vehiculo.Find(id);
            if (nE_Vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(nE_Vehiculo);
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.NE_Categoria, "CategoriaId", "CategoriaId");
            ViewBag.ColorId = new SelectList(db.NE_Color, "ColorId", "Color");
            ViewBag.MarcaId = new SelectList(db.NE_Marca, "MarcaId", "MarcaId");
            ViewBag.TransmisionId = new SelectList(db.NE_Transmision, "TransmisionId", "Transmision");
            return View();
        }

        // POST: Vehiculo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehiculoId,CategoriaId,MarcaId,Modelo,TransmisionId,ColorId,PrecioVenta,PrecioCompra,Descripcion,Activo")] NE_Vehiculo nE_Vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.NE_Vehiculo.Add(nE_Vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.NE_Categoria, "CategoriaId", "CategoriaId", nE_Vehiculo.CategoriaId);
            ViewBag.ColorId = new SelectList(db.NE_Color, "ColorId", "Color", nE_Vehiculo.ColorId);
            ViewBag.MarcaId = new SelectList(db.NE_Marca, "MarcaId", "MarcaId", nE_Vehiculo.MarcaId);
            ViewBag.TransmisionId = new SelectList(db.NE_Transmision, "TransmisionId", "Transmision", nE_Vehiculo.TransmisionId);
            return View(nE_Vehiculo);
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Vehiculo nE_Vehiculo = db.NE_Vehiculo.Find(id);
            if (nE_Vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.NE_Categoria, "CategoriaId", "CategoriaId", nE_Vehiculo.CategoriaId);
            ViewBag.ColorId = new SelectList(db.NE_Color, "ColorId", "Color", nE_Vehiculo.ColorId);
            ViewBag.MarcaId = new SelectList(db.NE_Marca, "MarcaId", "MarcaId", nE_Vehiculo.MarcaId);
            ViewBag.TransmisionId = new SelectList(db.NE_Transmision, "TransmisionId", "Transmision", nE_Vehiculo.TransmisionId);
            return View(nE_Vehiculo);
        }

        // POST: Vehiculo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehiculoId,CategoriaId,MarcaId,Modelo,TransmisionId,ColorId,PrecioVenta,PrecioCompra,Descripcion,Activo")] NE_Vehiculo nE_Vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nE_Vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.NE_Categoria, "CategoriaId", "CategoriaId", nE_Vehiculo.CategoriaId);
            ViewBag.ColorId = new SelectList(db.NE_Color, "ColorId", "Color", nE_Vehiculo.ColorId);
            ViewBag.MarcaId = new SelectList(db.NE_Marca, "MarcaId", "MarcaId", nE_Vehiculo.MarcaId);
            ViewBag.TransmisionId = new SelectList(db.NE_Transmision, "TransmisionId", "Transmision", nE_Vehiculo.TransmisionId);
            return View(nE_Vehiculo);
        }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Vehiculo nE_Vehiculo = db.NE_Vehiculo.Find(id);
            if (nE_Vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(nE_Vehiculo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NE_Vehiculo nE_Vehiculo = db.NE_Vehiculo.Find(id);
            db.NE_Vehiculo.Remove(nE_Vehiculo);
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

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
    public class ProductoController : Controller
    {
        private NE_Entity db = new NE_Entity();

        // GET: Producto
        public ActionResult Index()
        {
            return View(new List<NE_Producto>());
            //var nE_Producto = db.NE_Producto.Include(n => n.NE_Category);
            //return View(nE_Producto.ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Producto nE_Producto = db.NE_Producto.Find(id);
            if (nE_Producto == null)
            {
                return HttpNotFound();
            }
            return View(nE_Producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.Id_Category = new SelectList(db.NE_Category, "Id_Category", "Category");
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Producto,Descripcion,Nombre,Codigo,Stock,Precio_Venta,Precio_Compra,Activo,Id_Category")] NE_Producto nE_Producto)
        {
            if (ModelState.IsValid)
            {
                db.NE_Producto.Add(nE_Producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Category = new SelectList(db.NE_Category, "Id_Category", "Category", nE_Producto.Id_Category);
            return View(nE_Producto);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Producto nE_Producto = db.NE_Producto.Find(id);
            if (nE_Producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Category = new SelectList(db.NE_Category, "Id_Category", "Category", nE_Producto.Id_Category);
            return View(nE_Producto);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Producto,Descripcion,Nombre,Codigo,Stock,Precio_Venta,Precio_Compra,Activo,Id_Category")] NE_Producto nE_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nE_Producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Category = new SelectList(db.NE_Category, "Id_Category", "Category", nE_Producto.Id_Category);
            return View(nE_Producto);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Producto nE_Producto = db.NE_Producto.Find(id);
            if (nE_Producto == null)
            {
                return HttpNotFound();
            }
            return View(nE_Producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NE_Producto nE_Producto = db.NE_Producto.Find(id);
            db.NE_Producto.Remove(nE_Producto);
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

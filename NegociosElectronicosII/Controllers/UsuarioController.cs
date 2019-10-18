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
    public class UsuarioController : Controller
    {
        private DB_NE_Entitties db = new DB_NE_Entitties();

        // GET: Usuario
        public ActionResult Index()
        {
            var nE_Usuario = db.NE_Usuario.Include(n => n.NE_Rol).Include(n => n.NE_Sexo);
            return View(nE_Usuario.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Usuario nE_Usuario = db.NE_Usuario.Find(id);
            if (nE_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(nE_Usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.RolId = new SelectList(db.NE_Rol, "RolId", "Rol");
            ViewBag.SexoId = new SelectList(db.NE_Sexo, "SexoId", "Sexo");
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioId,Nombre,ApellidoPaterno,ApellidoMaterno,SexoId,Edad,Direccion,Telefono,CorreoElectronico,Activo,RolId")] NE_Usuario nE_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.NE_Usuario.Add(nE_Usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RolId = new SelectList(db.NE_Rol, "RolId", "Rol", nE_Usuario.RolId);
            ViewBag.SexoId = new SelectList(db.NE_Sexo, "SexoId", "Sexo", nE_Usuario.SexoId);
            return View(nE_Usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Usuario nE_Usuario = db.NE_Usuario.Find(id);
            if (nE_Usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolId = new SelectList(db.NE_Rol, "RolId", "Rol", nE_Usuario.RolId);
            ViewBag.SexoId = new SelectList(db.NE_Sexo, "SexoId", "Sexo", nE_Usuario.SexoId);
            return View(nE_Usuario);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioId,Nombre,ApellidoPaterno,ApellidoMaterno,SexoId,Edad,Direccion,Telefono,CorreoElectronico,Activo,RolId")] NE_Usuario nE_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nE_Usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RolId = new SelectList(db.NE_Rol, "RolId", "Rol", nE_Usuario.RolId);
            ViewBag.SexoId = new SelectList(db.NE_Sexo, "SexoId", "Sexo", nE_Usuario.SexoId);
            return View(nE_Usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NE_Usuario nE_Usuario = db.NE_Usuario.Find(id);
            if (nE_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(nE_Usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NE_Usuario nE_Usuario = db.NE_Usuario.Find(id);
            db.NE_Usuario.Remove(nE_Usuario);
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

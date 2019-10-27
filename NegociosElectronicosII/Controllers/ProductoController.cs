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
        private DB_NE_Entitties db = new DB_NE_Entitties();
        

        // GET: Producto
        public ActionResult Index()
        {
            var nE_Producto = db.NE_Producto.Include(n => n.NE_Color).Include(n => n.NE_Marca);
            return View(nE_Producto.ToList());
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
            ViewBag.ColorId = new SelectList(db.NE_Color, "ColorId", "Color");
            ViewBag.MarcaId = new SelectList(db.NE_Marca, "MarcaId", "Marca");
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoId,Nombre,Descripcion,MarcaId,ColorId,Stock,PrecioVenta,PrecioCompra,Activo")] NE_Producto nE_Producto)
        {
            try
            {
                string mensaje;
                HttpPostedFileBase postedFile = Request.Files[0];

                if (ModelState.IsValid)
                {
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {
                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {
                            mensaje = "Porfavor actualiza la imagen a estension de tipo .jpg,.gif,.png.";
                        }
                        else
                        {
                            db.NE_Producto.Add(nE_Producto);
                            db.SaveChanges();

                            var name = String.Format("Product_{0}",nE_Producto.ProductoId);
                            //var filePath = Server.MapPath("~/Imagenes/Productos/" + postedFile.FileName + extension);
                            var filePath = Server.MapPath("~/Imagenes/Productos/" + name + extension);

                            NE_ProductoImagen imagen = new NE_ProductoImagen()
                            {
                                Extension = extension,
                                Nombre = name,
                                ProductoId = nE_Producto.ProductoId,
                                Ruta = filePath,
                            };
                            db.NE_ProductoImagen.Add(imagen);
                            db.SaveChanges();

                            postedFile.SaveAs(filePath);

                            return RedirectToAction("Index");
                        }
                    }

                }

                ViewBag.ColorId = new SelectList(db.NE_Color, "ColorId", "Color", nE_Producto.ColorId);
                ViewBag.MarcaId = new SelectList(db.NE_Marca, "MarcaId", "Marca", nE_Producto.MarcaId);




                return View(nE_Producto);
            }
            catch (Exception ex){
                return View(nE_Producto);
            }
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
            ViewBag.ColorId = new SelectList(db.NE_Color, "ColorId", "Color", nE_Producto.ColorId);
            ViewBag.MarcaId = new SelectList(db.NE_Marca, "MarcaId", "Marca", nE_Producto.MarcaId);
            return View(nE_Producto);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoId,Nombre,Descripcion,MarcaId,ColorId,Stock,PrecioVenta,PrecioCompra,Activo")] NE_Producto nE_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nE_Producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorId = new SelectList(db.NE_Color, "ColorId", "Color", nE_Producto.ColorId);
            ViewBag.MarcaId = new SelectList(db.NE_Marca, "MarcaId", "Marca", nE_Producto.MarcaId);
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

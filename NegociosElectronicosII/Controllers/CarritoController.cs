using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NegociosElectronicosII.Models;

namespace NegociosElectronicosII.Controllers
{
    public class CarritoController : BaseController 
    {
        // GET: Carrito
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AgregarCarro(int id, int constante)
        {
            
            if (Settings.LoggedUser == null)
                return Json(new { Success = false, Message = "Necesitas iniciar sesion" }, JsonRequestBehavior.DenyGet);
            
            NE_Carrito nE_Carrito;
            if (constante == 1)
            {
                if(db.NE_Carrito.Any(x=>x.VehiculoId==id))
                    return Json(new { Success = false, Message = "Este articulo ya esta en el carrito" }, JsonRequestBehavior.DenyGet);
                nE_Carrito = new NE_Carrito()
                {
                    RecordDate = DateTime.Now,
                    UsuarioId = Settings.LoggedUser.UsuarioId,
                    ProductoId = null,
                    VehiculoId = id,

                };
            }
            else
            {
                if (db.NE_Carrito.Any(x => x.ProductoId == id))
                    return Json(new { Success = false, Message = "Este articulo ya esta en el carrito" }, JsonRequestBehavior.DenyGet);
                nE_Carrito = new NE_Carrito()
                {
                    RecordDate = DateTime.Now,
                    UsuarioId = Settings.LoggedUser.UsuarioId,
                    ProductoId = id,
                    VehiculoId = null,

                };
            }
            db.NE_Carrito.Add(nE_Carrito);
            db.SaveChanges();
            return Json(new { Success = true, Message = "Añadido al Carrito" }, JsonRequestBehavior.DenyGet);
        }

        public PartialViewResult CarritoDesplegable()
        {
            if (Settings.LoggedUser != null)
            {
                int numero = db.NE_Carrito.Where(x => x.UsuarioId == Settings.LoggedUser.UsuarioId).Count();
                ViewBag.TotalCarro = numero;
                return PartialView();
            }
            else
                return PartialView();
        }

        [HttpPost]
        public JsonResult EliminarCarro(int id, int constante)
        {

            if (Settings.LoggedUser == null)
                return Json(new { Success = false, Message = "Necesitas iniciar sesion" }, JsonRequestBehavior.DenyGet);
            NE_Carrito nE_Carrito= new NE_Carrito();
            if (constante == 1)
            {
                nE_Carrito = db.NE_Carrito.Where(x=>x.VehiculoId==id).First();

            }
            else
            {
                nE_Carrito = db.NE_Carrito.Where(x => x.ProductoId == id).First();
            }
            db.NE_Carrito.Remove(nE_Carrito);
            db.SaveChanges();
            return Json(new { Success = true, Message = "Se elimino el producto" }, JsonRequestBehavior.DenyGet);
        }




    }
}
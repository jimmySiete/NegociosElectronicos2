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



    }
}
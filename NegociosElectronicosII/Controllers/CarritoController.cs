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
            
                NE_Carrito nE_Carrito = new NE_Carrito()
                {
                    RecordDate = DateTime.Now,
                    UsuarioId = 1,
                    ProductoId = id,
                    VehiculoId = 1,

                };
            
            db.NE_Carrito.Add(nE_Carrito);
            db.SaveChanges();
            return Json(new { Success = true, Message = id }, JsonRequestBehavior.DenyGet);
        }
    }
}
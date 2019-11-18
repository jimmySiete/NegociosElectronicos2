using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NegociosElectronicosII.Models;

namespace NegociosElectronicosII.Controllers
{
    public class PagosController : BaseController
    {
       
        // GET: Pagos
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult FormasPago()
        {
            return PartialView();
        }
        

        [HttpPost]
        public JsonResult AgregarVenta(int tipo, string precio)
        {
           
            if (Settings.LoggedUser == null)
                return Json(new { Success = false, Message = "Necesitas iniciar sesion" }, JsonRequestBehavior.DenyGet);

            NE_Venta nE_Venta = new NE_Venta()
                {
                    UsuarioId = Settings.LoggedUser.UsuarioId,
                    TipoPagoId = tipo,
                    Fecha = DateTime.Now,
                    TotalVenta = Convert.ToInt32(precio),
                };
            db.NE_Venta.Add(nE_Venta);
            db.SaveChanges();
            return Json(new { Success = true, Message = "Pedido realizado con exito" }, JsonRequestBehavior.DenyGet);
        }
    }
}
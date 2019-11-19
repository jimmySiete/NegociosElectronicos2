using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NegociosElectronicosII.Models;

namespace NegociosElectronicosII.Controllers
{
    public class ListaDeseosController : BaseController
    {
        // GET: ListaDeseos
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AgregarDeseo(int id, int constante)
        {

            if (Settings.LoggedUser == null)
                return Json(new { Success = false, Message = "Necesitas iniciar sesion" }, JsonRequestBehavior.DenyGet);
            NE_ListaDeDeseos nE_ListaDeseos;
            if (constante == 1)
            {
                if (db.NE_ListaDeDeseos.Any(x => x.VehiculoId == id && x.UsuarioId == Settings.LoggedUser.UsuarioId))
                    return Json(new { Success = false, Message = "Este articulo ya esta en la lista de deseos" }, JsonRequestBehavior.DenyGet);

                nE_ListaDeseos = new NE_ListaDeDeseos()
                {
                    RecordDate = DateTime.Now,
                    UsuarioId = Settings.LoggedUser.UsuarioId,
                    ProductoId = null,
                    VehiculoId = id,

                };
            }
            else
            {
                if (db.NE_ListaDeDeseos.Any(x => x.ProductoId == id && x.UsuarioId == Settings.LoggedUser.UsuarioId))
                    return Json(new { Success = false, Message = "Este articulo ya esta en la Lista de deseos" }, JsonRequestBehavior.DenyGet);

                nE_ListaDeseos = new NE_ListaDeDeseos()
                {
                    RecordDate = DateTime.Now,
                    UsuarioId = Settings.LoggedUser.UsuarioId,
                    ProductoId = id,
                    VehiculoId = null,

                };
            }
            db.NE_ListaDeDeseos.Add(nE_ListaDeseos);
            db.SaveChanges();
            return Json(new { Success = true, Message = "Se añadio a la lista de deseos" }, JsonRequestBehavior.DenyGet);
        }
        public PartialViewResult ListaDesplegable()
        {
            if (Settings.LoggedUser != null)
            {
                int numero = db.NE_ListaDeDeseos.Where(x => x.UsuarioId == Settings.LoggedUser.UsuarioId).Count();
                ViewBag.TotalDeseos = numero;
                return PartialView();
            }
            else
                return PartialView();
        }
        [HttpPost]
        public JsonResult EliminarDeseado(int id, int constante)
        {

            if (Settings.LoggedUser == null)
                return Json(new { Success = false, Message = "Necesitas iniciar sesion" }, JsonRequestBehavior.DenyGet);
            NE_ListaDeDeseos nE_ListaDeseos = new NE_ListaDeDeseos();
            if (constante == 1)
            {
                nE_ListaDeseos = db.NE_ListaDeDeseos.Where(x => x.VehiculoId == id).First();

            }
            else
            {
                nE_ListaDeseos = db.NE_ListaDeDeseos.Where(x => x.ProductoId == id).First();
            }
            db.NE_ListaDeDeseos.Remove(nE_ListaDeseos);
            db.SaveChanges();
            return Json(new { Success = true, Message = "Se elimino el producto de Deseados" }, JsonRequestBehavior.DenyGet);
        }
    }
}
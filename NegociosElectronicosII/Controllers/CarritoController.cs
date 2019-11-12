using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return Json(new { Success = true, Message = id }, JsonRequestBehavior.DenyGet);
        }
    }
}
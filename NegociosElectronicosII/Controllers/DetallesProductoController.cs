using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NegociosElectronicosII.Models;

namespace NegociosElectronicosII.Controllers
{
    public class DetallesProductoController : BaseController
    {
        // GET: DetallesProducto
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public PartialViewResult Detalles(int idprod,int tipoprod)
        {
            DetallesModal detalles = new DetallesModal();
            detalles.tipo = tipoprod;
            if (tipoprod == 1)
                detalles.vehiculo = db.NE_Vehiculo.Where(x => x.VehiculoId == idprod).First();
            else
                detalles.producto = db.NE_Producto.Where(x => x.ProductoId == idprod).First();
             
            return PartialView(detalles);


        }
    }
}
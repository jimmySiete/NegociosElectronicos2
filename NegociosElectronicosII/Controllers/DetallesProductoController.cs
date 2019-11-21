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
            {
                detalles.vehiculo = db.NE_Vehiculo.Where(x => x.VehiculoId == idprod).First();
                if (Settings.LoggedUser != null)
                {
                    NE_ArticuloVehiculoVisto vehiculoVisto = new NE_ArticuloVehiculoVisto()
                    {
                        ID_Producto = null,
                        ID_Usuario = Settings.LoggedUser.UsuarioId,
                        ID_Vehiculo = idprod,
                        RecordDate = DateTime.Now
                    };
                    db.NE_ArticuloVehiculoVisto.Add(vehiculoVisto);
                    db.SaveChanges();
                }
            }
            else
            {
                detalles.producto = db.NE_Producto.Where(x => x.ProductoId == idprod).First();
                if (Settings.LoggedUser != null)
                {
                    NE_ArticuloVehiculoVisto productoVisto = new NE_ArticuloVehiculoVisto()
                    {
                        ID_Producto = idprod,
                        ID_Usuario = Settings.LoggedUser.UsuarioId,
                        ID_Vehiculo = null,
                        RecordDate = DateTime.Now
                    };
                    db.NE_ArticuloVehiculoVisto.Add(productoVisto);
                    db.SaveChanges();
                }
            }
             
            return PartialView(detalles);


        }
    }
}
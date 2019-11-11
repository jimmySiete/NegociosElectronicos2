using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NegociosElectronicosII.Models;

namespace NegociosElectronicosII.Controllers
{
    public class PrincipalController : BaseController
    {
        // GET: Principal
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult CarruselParcial()
        {
            List<NE_Carrusel> ImagenesCarrusel = db.NE_Carrusel.OrderBy(x=>x.Posicion).ToList();
            return PartialView(ImagenesCarrusel);
        }
        public PartialViewResult FiltroArticuloParcial()
        {
            List<NE_ProductoImagen> ImagenesVehiculo = db.NE_ProductoImagen.ToList();
            return PartialView(ImagenesVehiculo);
        }
        public PartialViewResult GridArticuloParcial()
        {
            List<NE_ProductoImagen> ImagenesVehiculo = db.NE_ProductoImagen.ToList();
            return PartialView(ImagenesVehiculo);
        }
        public PartialViewResult ArticuloParcial()
        {
            return PartialView();
        }
        public PartialViewResult VehiculoParcial()
        {
            return PartialView();
        }
        public PartialViewResult FiltroVehiculoParcial()
        {
            List<NE_VehiculoImagen> ImagenesVehiculo = db.NE_VehiculoImagen.ToList();
            return PartialView(ImagenesVehiculo);
        }
        public PartialViewResult GridVehiculoParcial()
        {
            List<NE_VehiculoImagen> ImagenesVehiculo = db.NE_VehiculoImagen.ToList();
            return PartialView(ImagenesVehiculo);
        }

        public ActionResult ListaDeDeseos() {

            return View();
        }

        public ActionResult CarritoDeCompras() {

            return View();
        }
    }
}
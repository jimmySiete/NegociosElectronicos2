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
        public PartialViewResult VehiculoParcial()
        {
            List<NE_Carrusel> ImagenesCarrusel = db.NE_Carrusel.OrderBy(x => x.Posicion).ToList();
            return PartialView(ImagenesCarrusel);
        }
        public PartialViewResult ArticuloParcial()
        {
            List<NE_Carrusel> ImagenesCarrusel = db.NE_Carrusel.OrderBy(x => x.Posicion).ToList();
            return PartialView(ImagenesCarrusel);
        }
    }
}
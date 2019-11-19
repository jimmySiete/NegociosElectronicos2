using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NegociosElectronicosII.GlobalCode;
using System.Web.Mvc;

namespace NegociosElectronicosII.Controllers
{
    [NegociosII_Auth(Roles = "1")]
    public class EstadisticaController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        #region Ganancias mensuales

        public PartialViewResult GananciaMensualParcial() {

            List<Int32> Anios = new List<int>();
            List<SelectListItem> fechas = new List<SelectListItem>();
            
            //Obtener la lista de los anios con ventas
            Anios = db.NE_Venta.Select(x => x.Fecha.Year).Distinct().ToList();
            if (!Anios.Contains(DateTime.Now.Year))
                Anios.Add(DateTime.Now.Year);

            //recorrer por anios
            foreach (var item in Anios)
            {
                foreach (var subitem in Settings.MESES)
                {
                    fechas.Add(new SelectListItem() { Value = subitem.Key.ToString() + "," + item.ToString(), Text = subitem.Value, Selected= (item==DateTime.Now.Year && DateTime.Now.Month== subitem.Key) });
                }
            }

            ViewBag.Fechas = fechas;

            return PartialView();
        }

        public PartialViewResult GananciaMensualDetalleParcial(Int32 Mes, Int32 Anio)
        {
            ViewBag.TotalVenta =
                db.NE_Venta.Where(x => x.Fecha.Month == Mes && x.Fecha.Year == Anio).Any()?
                db.NE_Venta.Where(x => x.Fecha.Month == Mes && x.Fecha.Year == Anio).Sum(x => x.TotalVenta) :0.0m;
            return PartialView();
        }

        #endregion

        #region Ganancias mensuales

        public PartialViewResult GananciaAnualParcial()
        {

            List<Int32> Anios = new List<int>();
            List<SelectListItem> fechas = new List<SelectListItem>();

            //Obtener la lista de los anios con ventas
            Anios = db.NE_Venta.Select(x => x.Fecha.Year).Distinct().ToList();
            if (!Anios.Contains(DateTime.Now.Year))
                Anios.Add(DateTime.Now.Year);

            //recorrer por anios
            foreach (var item in Anios)
            {
                fechas.Add(new SelectListItem() {
                    Text = item.ToString(),
                    Value = item.ToString()
                });
            }

            ViewBag.Fechas = fechas;

            return PartialView();
        }

        public PartialViewResult GananciaAnualDetalleParcial(Int32 Anio)
        {
            ViewBag.TotalVenta =
                db.NE_Venta.Where(x => x.Fecha.Year == Anio).Any() ?
                db.NE_Venta.Where(x => x.Fecha.Year == Anio).Sum(x => x.TotalVenta) : 0.0m;
            return PartialView();
        }

        #endregion

        #region Cantidad de vehiculos vendidos

        public PartialViewResult VehiculosVendidosPartial() {
            List<SelectListItem> Anios = new List<SelectListItem>();
            return PartialView();
        }

        public PartialViewResult VehiculosVendidosDetalleParcial(Int32 Mes, Int32 Anio) {

            return PartialView();
        }
        #endregion

    }
}
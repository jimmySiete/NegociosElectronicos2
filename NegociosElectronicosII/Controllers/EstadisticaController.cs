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
            List<SelectListItem> Meses = new List<SelectListItem>();
            List<Int32> _Anios = new List<int>();

            _Anios = db.NE_Venta.Select(x => x.Fecha.Year).Distinct().ToList();
            if (!_Anios.Contains(DateTime.Now.Year))
                _Anios.Add(DateTime.Now.Year);

            Anios = _Anios.Select(x => new SelectListItem() { Text=x.ToString(), Value=x.ToString() }).ToList();

            foreach (var item in Settings.MESES)
                Meses.Add(new SelectListItem() {
                    Text = item.Value,
                    Value = item.Key.ToString(),
                    Selected = item.Key == DateTime.Now.Month
                });

            ViewBag.Anios = Anios;
            ViewBag.Meses = Meses;

            return PartialView();
        }

        public PartialViewResult VehiculosVendidosDetalleParcial(Int32 Mes, Int32 Anio) {

            //ViewBag.NumeroDeAutos= db.NE_Venta.Where(x => x.Fecha.Month == Mes && x.Fecha.Year == Anio).Count();
            ViewBag.NumeroDeAutos= db.NE_VentaDetalle.Any(x=>x.VehiculoId!=null && x.NE_Venta.Fecha.Month == Mes && x.NE_Venta.Fecha.Year == Anio)?
                db.NE_VentaDetalle.Where(x => x.VehiculoId != null && x.NE_Venta.Fecha.Month == Mes && x.NE_Venta.Fecha.Year == Anio).Sum(x => x.Cantidad) : 0;
            return PartialView();
        }

        #endregion

        #region Cantidad de articulos vendidos

        public PartialViewResult ArticulosVendidosPartial() {
            List<SelectListItem> Anios = new List<SelectListItem>();
            List<SelectListItem> Meses = new List<SelectListItem>();
            List<Int32> _Anios = new List<int>();

            _Anios = db.NE_Venta.Select(x => x.Fecha.Year).Distinct().ToList();
            if (!_Anios.Contains(DateTime.Now.Year))
                _Anios.Add(DateTime.Now.Year);

            Anios = _Anios.Select(x => new SelectListItem() { Text = x.ToString(), Value = x.ToString() }).ToList();

            foreach (var item in Settings.MESES)
                Meses.Add(new SelectListItem()
                {
                    Text = item.Value,
                    Value = item.Key.ToString(),
                    Selected = item.Key == DateTime.Now.Month
                });

            ViewBag.Anios = Anios;
            ViewBag.Meses = Meses;

            return PartialView();
        }

        public PartialViewResult ArticulosVendidosDetalleParcial(Int32 Mes, Int32 Anio)
        {
            //ViewBag.NumeroDeArticulos = db.NE_Venta.Where(x => x.Fecha.Month == Mes && x.Fecha.Year == Anio).Count();
            ViewBag.NumeroDeArticulos = db.NE_VentaDetalle.Any(x => x.ProductoId != null && x.NE_Venta.Fecha.Month == Mes && x.NE_Venta.Fecha.Year == Anio)?
                db.NE_VentaDetalle.Where(x => x.ProductoId != null && x.NE_Venta.Fecha.Month == Mes && x.NE_Venta.Fecha.Year == Anio).Sum(x=>x.Cantidad) : 0;
            return PartialView();
        }


        #endregion

        #region Usuarios

        public PartialViewResult FiltrosUsuariosParcial() {
            List<SelectListItem> Anios = new List<SelectListItem>();
            List<SelectListItem> Meses = new List<SelectListItem>();
            List<Int32> _Anios = new List<int>();

            _Anios = db.NE_Venta.Select(x => x.Fecha.Year).Distinct().ToList();
            if (!_Anios.Contains(DateTime.Now.Year))
                _Anios.Add(DateTime.Now.Year);

            Anios = _Anios.Select(x => new SelectListItem() { Text = x.ToString(), Value = x.ToString() }).ToList();

            foreach (var item in Settings.MESES)
                Meses.Add(new SelectListItem()
                {
                    Text = item.Value,
                    Value = item.Key.ToString(),
                    Selected = item.Key == DateTime.Now.Month
                });

            ViewBag.Anios = Anios;
            ViewBag.Meses = Meses;

            return PartialView();
        }

        public PartialViewResult FiltrosUsuariosDetalleParcial(Int32 Mes, Int32 Anio) {

            ViewBag.NumerosDeUsuariosLogueados= db.NE_Bitacora.Where(x => x.FechaDeRegistro.Month == Mes && x.FechaDeRegistro.Year == Anio && x.AccionId == ACCION.INICIO_DE_SESION).Count();
            ViewBag.NumerosDeUsuariosRegistrados = db.NE_Bitacora.Where(x => x.FechaDeRegistro.Month == Mes && x.FechaDeRegistro.Year == Anio && x.AccionId == ACCION.NUEVO_REGISTRO).Count();
            ViewBag.NumeroDeUsuariosQueHicieronCompras = db.NE_Bitacora.Where(x => x.FechaDeRegistro.Month == Mes && x.FechaDeRegistro.Year == Anio && x.AccionId == ACCION.COMPRA).Count();

            return PartialView();
        }

        #endregion

        #region Usuarios con mas ventas

        public PartialViewResult UsuariosConMasVentas() {

            List<Models.UsuarioReporteModel> model= db.NE_Venta.GroupBy(x => new { x.NE_Usuario.Nombre, x.NE_Usuario.ApellidoPaterno})
                .Select(x=>new Models.UsuarioReporteModel() {
                    Total= 0,
                    Usuario= x.Key.Nombre + " " + x.Key.ApellidoPaterno
                }).ToList().OrderByDescending(x=>x.Total).Take(5).ToList();
            return PartialView(model);
        }

        #endregion

    }
}
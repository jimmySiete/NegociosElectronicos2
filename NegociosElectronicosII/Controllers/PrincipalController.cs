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
            List<OfertaModel> ofertas = new List<OfertaModel>();
            //se obtienen las imagenes del carrusel
            List<NE_Carrusel> ImagenesCarrusel = db.NE_Carrusel.OrderBy(x => x.Posicion).ToList();
            try
            {
                //si hay objetos con oferta, lo agregamos a la lista
                if (db.NE_Producto.Any(x => x.MarcarComoOferta))
                {
                    List<OfertaModel> ofertaProducto = db.NE_Producto.Where(x => x.MarcarComoOferta).Select(x => new OfertaModel()
                    {
                        IsProduct = true,
                        Text = x.Nombre,
                        ID= x.ProductoId
                    }).ToList();

                    foreach (var item in ofertaProducto) 
                        if (db.NE_ProductoImagen.Any(x => x.ProductoId == item.ID))
                            item.ImagenesProducto.AddRange(db.NE_ProductoImagen.Where(x => x.ProductoId == item.ID));
                    
                    ofertas.AddRange(ofertaProducto);
                }

                //si hay autos con oferta, lo agregamos a la lista
                if (db.NE_Vehiculo.Any(x => x.MarcarComoOferta))
                {
                    List<OfertaModel> ofertaVehiculo = db.NE_Vehiculo.Where(x => x.MarcarComoOferta).Select(x => new OfertaModel()
                    {
                        IsProduct = true,
                        Text = x.NombreVehiculo + " " + x.Descripcion,
                        ID= x.VehiculoId
                    }).ToList();

                    foreach (var item in ofertaVehiculo)
                        if (db.NE_VehiculoImagen.Any(x => x.VehiculoId == item.ID))
                            item.ImagenesVehiculo.AddRange(db.NE_VehiculoImagen.Where(x => x.VehiculoId == item.ID));

                    ofertas.AddRange(ofertaVehiculo);
                }


                //ordenar aleatoriamente en el arreglo
                ofertas = DesordenarLista(ofertas);

                //obtener la listas de marcas disponibles
                ViewBag.Marcas = db.NE_Marca.ToList();
                //agregar ofertas a ViewBag
                ViewBag.Ofertas = ofertas.Take(4).ToList();

                return PartialView(ImagenesCarrusel);
            }
            catch (Exception ex)
            {
                return PartialView(ImagenesCarrusel);
            }
        }
        public PartialViewResult FiltroArticuloParcial()
        {
            ViewBag.Marcas = db.NE_Marca.ToList();
            ViewBag.Color = db.NE_Color.ToList();
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
            ViewBag.Marcas = db.NE_Marca.ToList();
            ViewBag.Color = db.NE_Color.ToList();
            ViewBag.Categoria = db.NE_Categoria.ToList();
            ViewBag.Transmision= db.NE_Transmision.ToList();
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
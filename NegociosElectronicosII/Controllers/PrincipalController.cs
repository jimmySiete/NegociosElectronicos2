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
        /// <summary>
        /// Pagina principal
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Vista del carrusel
        /// </summary>
        /// <returns></returns>
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

        #region Vehiculos

        /// <summary>
        /// Vista parcial del vehiculo
        /// </summary>
        /// <returns></returns>
        public PartialViewResult VehiculoParcial()
        {
            return PartialView();
        }

        /// <summary>
        /// Vista del fiiltro del vehiculo
        /// </summary>
        /// <returns></returns>
        public PartialViewResult FiltroVehiculoParcial()
        {
            ViewBag.Marcas = db.NE_Marca.ToList();
            ViewBag.Color = db.NE_Color.ToList();
            ViewBag.Categoria = db.NE_Categoria.ToList();
            ViewBag.Transmision = db.NE_Transmision.ToList();
            List<NE_VehiculoImagen> ImagenesVehiculo = db.NE_VehiculoImagen.ToList();
            return PartialView(ImagenesVehiculo);
        }

        public PartialViewResult GridVehiculoParcial(Int32 Pagina,String Marcas,String Color, String Categoria, String Transmision, Decimal PrecioInicial, Decimal PrecioFinal)
        {
            //Se crean listas vacias en donde vaciaremos los strings de la vista
            List<Int32> Ids_Marcas = new List<int>();
            List<Int32> Ids_Color = new List<int>();
            List<Int32> Ids_Categorias = new List<int>();
            List<Int32> Ids_Transmision = new List<int>();

            //obtener precio inicial y precio final max y min
            Decimal Max = db.NE_Vehiculo.Max(x => x.MarcarComoOferta? x.PrecioOFerta: x.PrecioVenta);
            Decimal Min = db.NE_Vehiculo.Min(x => x.MarcarComoOferta ? x.PrecioOFerta : x.PrecioVenta);

            //si la variable marcas viene como null o vacio entonces toma el arreglo del catalogo
            if (!String.IsNullOrEmpty(Marcas))
                Ids_Marcas = Marcas.Split(',').ToList().Select(Int32.Parse).ToList();
            else
                Ids_Marcas = db.NE_Marca.Select(x => x.MarcaId).ToList();

            //si la variable color viene como null o vacio entonces toma el arreglo del catalogo
            if (!String.IsNullOrEmpty(Color))
                Ids_Color = Color.Split(',').ToList().Select(Int32.Parse).ToList();
            else
                Ids_Color = db.NE_Color.Select(x => x.ColorId).ToList();

            //si la variable categorias viene como null o vacio entonces toma el arreglo del catalogo
            if (!String.IsNullOrEmpty(Categoria))
                Ids_Categorias = Categoria.Split(',').ToList().Select(Int32.Parse).ToList();
            else
                Ids_Categorias = db.NE_Categoria.Select(x => x.CategoriaId).ToList();

            //si la variable categorias viene como null o vacio entonces toma el arreglo del catalogo
            if (!String.IsNullOrEmpty(Transmision))
                Ids_Transmision = Transmision.Split(',').ToList().Select(Int32.Parse).ToList();
            else
                Ids_Transmision = db.NE_Transmision.Select(x => x.TransmisionId).ToList();


            //obtenemos el filtro de los vehiculos seleccionados y lo convertimos a lista
            List<NE_VehiculoImagen> ImagenesVehiculo = db.NE_VehiculoImagen
                .Where(x=>  
                    Ids_Marcas.Contains(x.NE_Vehiculo.MarcaId) 
                    && Ids_Color.Contains(x.NE_Vehiculo.ColorId)
                    && Ids_Categorias.Contains(x.NE_Vehiculo.CategoriaId)
                    && Ids_Transmision.Contains(x.NE_Vehiculo.TransmisionId)
                    && (
                            (x.NE_Vehiculo.MarcarComoOferta? x.NE_Vehiculo.PrecioOFerta : x.NE_Vehiculo.PrecioVenta) > (PrecioInicial<= 0? Min : PrecioInicial)
                            &&
                            (x.NE_Vehiculo.MarcarComoOferta ? x.NE_Vehiculo.PrecioOFerta : x.NE_Vehiculo.PrecioVenta) > (PrecioFinal <= 0 ? Min : PrecioFinal)
                        )
                )
                .ToList();

            //Se obtiene el total de los vehiculos
            Int32 TotalDeVehiculos = ImagenesVehiculo.Count();
            //Se obtiene el total de paginas a pintar
            Int32 NumeroDePaginas = (ImagenesVehiculo.Count() / Settings.NUMERO_DE_ITEMS_POR_PAGINA) +1;
            //Se obtiene el registro del primer salto de pagina
            Int32 skip = ((Pagina-1) * Settings.NUMERO_DE_ITEMS_POR_PAGINA);
            
            //Se filtra por el paginado de la pagina
            ImagenesVehiculo = ImagenesVehiculo.Skip(skip).Take(Settings.NUMERO_DE_ITEMS_POR_PAGINA).ToList();

            //Se pintan en los Viebags los montos, para usarlos en la vista
            ViewBag.TotalDeVehiculos = TotalDeVehiculos;
            ViewBag.NumeroDePaginas = NumeroDePaginas;
            ViewBag.PaginaActual = Pagina;
            return PartialView(ImagenesVehiculo);
        }


        #endregion

        public PartialViewResult ArticuloParcial()
        {
            return PartialView();
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

        public ActionResult ListaDeDeseos() {

            return View();
        }

        public ActionResult CarritoDeCompras() {

            return View();
        }
    }
}
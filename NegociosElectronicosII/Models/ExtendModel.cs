using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NegociosElectronicosII.Models
{
    public class ExtendModel
    {
    }
    #region NE_Vehiculos
    [MetadataType(typeof(MetadataVehiculo))]
    public partial class NE_Vehiculo
    {

    }
    public class MetadataVehiculo
    {
        [Key]
        public int VehiculoId { get; set; }
        [Display(Name = "CategoriaId", ResourceType = (typeof(Recursos)))]
        public int CategoriaId { get; set; }
        [Display(Name = "MarcaId", ResourceType = (typeof(Recursos)))]
        public int MarcaId { get; set; }
        public int Modelo { get; set; }
        [Display(Name = "TransmId", ResourceType = (typeof(Recursos)))]
        public int TransmisionId { get; set; }
        [Display(Name = "ColorId", ResourceType = (typeof(Recursos)))]
        public int ColorId { get; set; }
        [Display(Name="PrecioVenta", ResourceType=(typeof(Recursos)))]
        public decimal PrecioVenta { get; set; }
        [Display(Name = "PrecioCompra", ResourceType = (typeof(Recursos)))]
        public decimal PrecioCompra { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

    }
    #endregion
    #region NE_Producto
    [MetadataType(typeof(MetadataProducto))]
    public partial class NE_Producto
    {
        public string password { get; set; }
    }
    public class MetadataProducto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Display(Name = "MarcaId", ResourceType = (typeof(Recursos)))]
        public int MarcaId { get; set; }
        [Display(Name = "ColorId", ResourceType = (typeof(Recursos)))]
        public int ColorId { get; set; }
        public int Stock { get; set; }
        [Display(Name = "PrecioVenta", ResourceType = (typeof(Recursos)))]
        public decimal PrecioVenta { get; set; }
        [Display(Name = "PrecioCompra", ResourceType = (typeof(Recursos)))]
        public decimal PrecioCompra { get; set; }
        public bool Activo { get; set; }
    }
    #endregion
    #region NE_Usuario
    [MetadataType(typeof(MetadataUsuario))]
    public partial class NE_Usuario
    {

    }
    public class MetadataUsuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        [Display(Name ="Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        [Display(Name = "SexoId", ResourceType = (typeof(Recursos)))]
        public int SexoId { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        [Display(Name = "Email", ResourceType = (typeof(Recursos)))]
        public string CorreoElectronico { get; set; }
        public bool Activo { get; set; }
        [Display(Name = "RolId", ResourceType = (typeof(Recursos)))]
        public int RolId { get; set; }

    }
    #endregion
}
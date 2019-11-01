//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NegociosElectronicosII.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NE_Vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NE_Vehiculo()
        {
            this.NE_ComentarioVehiculo = new HashSet<NE_ComentarioVehiculo>();
            this.NE_VehiculoImagen = new HashSet<NE_VehiculoImagen>();
        }
    
        public int VehiculoId { get; set; }
        public int CategoriaId { get; set; }
        public int MarcaId { get; set; }
        public int Modelo { get; set; }
        public int TransmisionId { get; set; }
        public int ColorId { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public byte[] NombreVehiculo { get; set; }
    
        public virtual NE_Categoria NE_Categoria { get; set; }
        public virtual NE_Color NE_Color { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_ComentarioVehiculo> NE_ComentarioVehiculo { get; set; }
        public virtual NE_Marca NE_Marca { get; set; }
        public virtual NE_Transmision NE_Transmision { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_VehiculoImagen> NE_VehiculoImagen { get; set; }
    }
}

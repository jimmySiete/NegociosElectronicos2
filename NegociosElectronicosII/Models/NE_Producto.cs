//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NegociosElectronicosII.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NE_Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NE_Producto()
        {
            this.NE_ComentarioProducto = new HashSet<NE_ComentarioProducto>();
            this.NE_ProductoImagen = new HashSet<NE_ProductoImagen>();
            this.NE_Carrito = new HashSet<NE_Carrito>();
            this.NE_ListaDeDeseos = new HashSet<NE_ListaDeDeseos>();
            this.NE_VentaDetalle = new HashSet<NE_VentaDetalle>();
        }
    
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int MarcaId { get; set; }
        public int ColorId { get; set; }
        public int Stock { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public bool Activo { get; set; }
        public decimal PrecioOFerta { get; set; }
        public bool MarcarComoOferta { get; set; }
    
        public virtual NE_Color NE_Color { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_ComentarioProducto> NE_ComentarioProducto { get; set; }
        public virtual NE_Marca NE_Marca { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_ProductoImagen> NE_ProductoImagen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_Carrito> NE_Carrito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_ListaDeDeseos> NE_ListaDeDeseos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_VentaDetalle> NE_VentaDetalle { get; set; }
    }
}

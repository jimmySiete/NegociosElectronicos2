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
    
    public partial class NE_VentaDetalle
    {
        public int VentaDetalleId { get; set; }
        public int VentaId { get; set; }
        public Nullable<int> VehiculoId { get; set; }
        public Nullable<int> ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    
        public virtual NE_Producto NE_Producto { get; set; }
        public virtual NE_Vehiculo NE_Vehiculo { get; set; }
        public virtual NE_Venta NE_Venta { get; set; }
    }
}

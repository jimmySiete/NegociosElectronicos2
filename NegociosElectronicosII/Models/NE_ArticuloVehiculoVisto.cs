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
    
    public partial class NE_ArticuloVehiculoVisto
    {
        public int ID_ArticuloVehiculoVisto { get; set; }
        public Nullable<int> ID_Producto { get; set; }
        public Nullable<int> ID_Vehiculo { get; set; }
        public System.DateTime RecordDate { get; set; }
        public int ID_Usuario { get; set; }
    
        public virtual NE_Producto NE_Producto { get; set; }
        public virtual NE_Vehiculo NE_Vehiculo { get; set; }
        public virtual NE_Usuario NE_Usuario { get; set; }
    }
}

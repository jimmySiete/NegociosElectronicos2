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
    
    public partial class NE_TipoPago
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NE_TipoPago()
        {
            this.NE_Venta = new HashSet<NE_Venta>();
        }
    
        public int TipoPagoId { get; set; }
        public string TipoPago { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_Venta> NE_Venta { get; set; }
    }
}
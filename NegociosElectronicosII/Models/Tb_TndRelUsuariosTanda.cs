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
    
    public partial class Tb_TndRelUsuariosTanda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_TndRelUsuariosTanda()
        {
            this.Tb_TndPayments = new HashSet<Tb_TndPayments>();
            this.Tb_TndProducto = new HashSet<Tb_TndProducto>();
        }
    
        public int ID_RelUsuariosTanda { get; set; }
        public int ID_Tanda { get; set; }
        public int ID_Usuario { get; set; }
        public int Numero { get; set; }
        public System.DateTime FechaDeInicio { get; set; }
        public int ID_Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_TndPayments> Tb_TndPayments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_TndProducto> Tb_TndProducto { get; set; }
        public virtual Tb_TndStatusUsuarios Tb_TndStatusUsuarios { get; set; }
        public virtual Tb_TndTanda Tb_TndTanda { get; set; }
        public virtual Tb_TndUsuarios Tb_TndUsuarios { get; set; }
    }
}

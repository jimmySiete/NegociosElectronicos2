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
    
    public partial class Tb_Group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_Group()
        {
            this.Tb_Inventory = new HashSet<Tb_Inventory>();
            this.Tb_OutputNotes = new HashSet<Tb_OutputNotes>();
            this.Tb_RelProdWHControl = new HashSet<Tb_RelProdWHControl>();
            this.Tb_SalesReport = new HashSet<Tb_SalesReport>();
            this.Tb_TransportGuide = new HashSet<Tb_TransportGuide>();
            this.Tb_User = new HashSet<Tb_User>();
        }
    
        public int GroupId { get; set; }
        public string Group { get; set; }
        public Nullable<int> GroupIdToReport { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Inventory> Tb_Inventory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_OutputNotes> Tb_OutputNotes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_RelProdWHControl> Tb_RelProdWHControl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_SalesReport> Tb_SalesReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_TransportGuide> Tb_TransportGuide { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_User> Tb_User { get; set; }
    }
}

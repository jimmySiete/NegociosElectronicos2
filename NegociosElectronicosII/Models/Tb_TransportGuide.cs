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
    
    public partial class Tb_TransportGuide
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_TransportGuide()
        {
            this.Tb_RelWHC_TransGuide = new HashSet<Tb_RelWHC_TransGuide>();
            this.Tb_TransportGuideDetail = new HashSet<Tb_TransportGuideDetail>();
        }
    
        public long TransportGuideId { get; set; }
        public System.DateTime RercordDate { get; set; }
        public string Folio { get; set; }
        public long RouteId { get; set; }
        public int WeekendNumber { get; set; }
        public int Year { get; set; }
        public int GroupId { get; set; }
    
        public virtual Tb_Group Tb_Group { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_RelWHC_TransGuide> Tb_RelWHC_TransGuide { get; set; }
        public virtual Tb_Route Tb_Route { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_TransportGuideDetail> Tb_TransportGuideDetail { get; set; }
    }
}

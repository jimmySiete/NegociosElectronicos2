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
    
    public partial class Tb_TransportGuideDetail
    {
        public long TransportGuideDetailId { get; set; }
        public long TransportGuideId { get; set; }
        public long ProductId { get; set; }
        public int Exist { get; set; }
        public int Input { get; set; }
        public int Devolution { get; set; }
        public int Total { get; set; }
    
        public virtual Tb_Product Tb_Product { get; set; }
        public virtual Tb_TransportGuide Tb_TransportGuide { get; set; }
    }
}

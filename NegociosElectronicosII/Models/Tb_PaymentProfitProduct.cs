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
    
    public partial class Tb_PaymentProfitProduct
    {
        public long PaymentProfitProductId { get; set; }
        public long PaymentProfitId { get; set; }
        public int Payed { get; set; }
        public int Hitched { get; set; }
        public int NoHitched { get; set; }
        public int Canceled { get; set; }
        public int Total { get; set; }
        public int NumRow { get; set; }
        public long ProductId { get; set; }
        public long PaymentProfitRowId { get; set; }
    
        public virtual Tb_PaymentProfits Tb_PaymentProfits { get; set; }
        public virtual Tb_paymentsProfitsRows Tb_paymentsProfitsRows { get; set; }
    }
}

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
    
    public partial class Tb_InventoryPaymentProfit
    {
        public long InventoryPaymentProfitID { get; set; }
        public long PaymentProfitId { get; set; }
        public long ProductId { get; set; }
        public int Existency { get; set; }
        public int InProd { get; set; }
        public int Subtotal { get; set; }
        public int OutProd { get; set; }
        public int Total { get; set; }
    
        public virtual Tb_PaymentProfits Tb_PaymentProfits { get; set; }
        public virtual Tb_Product Tb_Product { get; set; }
    }
}

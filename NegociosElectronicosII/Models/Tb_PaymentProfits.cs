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
    
    public partial class Tb_PaymentProfits
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_PaymentProfits()
        {
            this.Tb_FilesPaymentProfits = new HashSet<Tb_FilesPaymentProfits>();
            this.Tb_InventoryPaymentProfit = new HashSet<Tb_InventoryPaymentProfit>();
            this.Tb_PaymentProfitProduct = new HashSet<Tb_PaymentProfitProduct>();
            this.Tb_paymentsProfitsRows = new HashSet<Tb_paymentsProfitsRows>();
            this.Tb_Rel_PP_Sales = new HashSet<Tb_Rel_PP_Sales>();
        }
    
        public long PaymentsProfitsId { get; set; }
        public System.DateTime DelieverDate { get; set; }
        public string Folio { get; set; }
        public long SellerID { get; set; }
        public int WeekNumber { get; set; }
        public int Year { get; set; }
        public decimal PaymentProfitAmount { get; set; }
        public decimal Deposit { get; set; }
        public decimal Commission { get; set; }
        public decimal Oil { get; set; }
        public decimal Stepway { get; set; }
        public decimal Assistant { get; set; }
        public decimal Toolman { get; set; }
        public decimal Other { get; set; }
        public decimal Expense { get; set; }
        public bool IsDeliever { get; set; }
        public decimal Subtotal { get; set; }
        public int Mileage { get; set; }
        public int Enrollment { get; set; }
        public decimal IMSS { get; set; }
        public decimal INFONAVIT { get; set; }
        public bool IsDiffToPay { get; set; }
        public decimal Total { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_FilesPaymentProfits> Tb_FilesPaymentProfits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_InventoryPaymentProfit> Tb_InventoryPaymentProfit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_PaymentProfitProduct> Tb_PaymentProfitProduct { get; set; }
        public virtual Tb_User Tb_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_paymentsProfitsRows> Tb_paymentsProfitsRows { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Rel_PP_Sales> Tb_Rel_PP_Sales { get; set; }
    }
}

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
    
    public partial class ENSES_User
    {
        public int ID_User { get; set; }
        public string Email { get; set; }
        public string User { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
        public int ID_Rol { get; set; }
    
        public virtual ENSES_Rol ENSES_Rol { get; set; }
    }
}

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
    
    public partial class NE_CuerpoChat
    {
        public int CuerpoChatId { get; set; }
        public int ChatId { get; set; }
        public System.DateTime FechaDeRegistro { get; set; }
        public string Mensaje { get; set; }
        public bool EsCliente { get; set; }
    
        public virtual NE_EncabezadoChat NE_EncabezadoChat { get; set; }
    }
}

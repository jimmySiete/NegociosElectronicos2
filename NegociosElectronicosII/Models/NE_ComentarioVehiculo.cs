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
    
    public partial class NE_ComentarioVehiculo
    {
        public int ComentarioVehiculoId { get; set; }
        public int VehiculoId { get; set; }
        public string Comentario { get; set; }
        public int UsuarioId { get; set; }
        public System.DateTime FechaRegistro { get; set; }
    
        public virtual NE_Usuario NE_Usuario { get; set; }
        public virtual NE_Vehiculo NE_Vehiculo { get; set; }
    }
}

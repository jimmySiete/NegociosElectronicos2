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
    
    public partial class NE_Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NE_Usuario()
        {
            this.NE_Autenticacion = new HashSet<NE_Autenticacion>();
            this.NE_Bitacora = new HashSet<NE_Bitacora>();
            this.NE_ComentarioProducto = new HashSet<NE_ComentarioProducto>();
            this.NE_ComentarioVehiculo = new HashSet<NE_ComentarioVehiculo>();
            this.NE_EncabezadoChat = new HashSet<NE_EncabezadoChat>();
            this.NE_RecoveryPassword = new HashSet<NE_RecoveryPassword>();
            this.NE_Visita = new HashSet<NE_Visita>();
            this.NE_Carrito = new HashSet<NE_Carrito>();
            this.NE_ListaDeDeseos = new HashSet<NE_ListaDeDeseos>();
            this.NE_Venta = new HashSet<NE_Venta>();
            this.NE_ArticuloVehiculoVisto = new HashSet<NE_ArticuloVehiculoVisto>();
        }
    
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int SexoId { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public bool Activo { get; set; }
        public int RolId { get; set; }
        public Nullable<System.DateTime> FechaDeRegistro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_Autenticacion> NE_Autenticacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_Bitacora> NE_Bitacora { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_ComentarioProducto> NE_ComentarioProducto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_ComentarioVehiculo> NE_ComentarioVehiculo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_EncabezadoChat> NE_EncabezadoChat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_RecoveryPassword> NE_RecoveryPassword { get; set; }
        public virtual NE_Rol NE_Rol { get; set; }
        public virtual NE_Sexo NE_Sexo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_Visita> NE_Visita { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_Carrito> NE_Carrito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_ListaDeDeseos> NE_ListaDeDeseos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_Venta> NE_Venta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NE_ArticuloVehiculoVisto> NE_ArticuloVehiculoVisto { get; set; }
    }
}

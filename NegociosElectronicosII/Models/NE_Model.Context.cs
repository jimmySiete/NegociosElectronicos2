﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_NE_Entitties : DbContext
    {
        public DB_NE_Entitties()
            : base("name=DB_NE_Entitties")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<NE_Accion> NE_Accion { get; set; }
        public virtual DbSet<NE_Autenticacion> NE_Autenticacion { get; set; }
        public virtual DbSet<NE_Bitacora> NE_Bitacora { get; set; }
        public virtual DbSet<NE_Carrusel> NE_Carrusel { get; set; }
        public virtual DbSet<NE_Categoria> NE_Categoria { get; set; }
        public virtual DbSet<NE_Color> NE_Color { get; set; }
        public virtual DbSet<NE_ComentarioProducto> NE_ComentarioProducto { get; set; }
        public virtual DbSet<NE_ComentarioVehiculo> NE_ComentarioVehiculo { get; set; }
        public virtual DbSet<NE_CuerpoChat> NE_CuerpoChat { get; set; }
        public virtual DbSet<NE_EmailTemplate> NE_EmailTemplate { get; set; }
        public virtual DbSet<NE_EncabezadoChat> NE_EncabezadoChat { get; set; }
        public virtual DbSet<NE_Encuesta> NE_Encuesta { get; set; }
        public virtual DbSet<NE_FAQS> NE_FAQS { get; set; }
        public virtual DbSet<NE_Marca> NE_Marca { get; set; }
        public virtual DbSet<NE_Producto> NE_Producto { get; set; }
        public virtual DbSet<NE_ProductoImagen> NE_ProductoImagen { get; set; }
        public virtual DbSet<NE_RecoveryPassword> NE_RecoveryPassword { get; set; }
        public virtual DbSet<NE_Rol> NE_Rol { get; set; }
        public virtual DbSet<NE_Sexo> NE_Sexo { get; set; }
        public virtual DbSet<NE_Template> NE_Template { get; set; }
        public virtual DbSet<NE_Transmision> NE_Transmision { get; set; }
        public virtual DbSet<NE_Usuario> NE_Usuario { get; set; }
        public virtual DbSet<NE_Vehiculo> NE_Vehiculo { get; set; }
        public virtual DbSet<NE_VehiculoImagen> NE_VehiculoImagen { get; set; }
        public virtual DbSet<NE_Visita> NE_Visita { get; set; }
        public virtual DbSet<NE_Carrito> NE_Carrito { get; set; }
        public virtual DbSet<NE_ListaDeDeseos> NE_ListaDeDeseos { get; set; }
        public virtual DbSet<NE_TipoPago> NE_TipoPago { get; set; }
        public virtual DbSet<NE_Venta> NE_Venta { get; set; }
        public virtual DbSet<NE_VentaDetalle> NE_VentaDetalle { get; set; }
    }
}

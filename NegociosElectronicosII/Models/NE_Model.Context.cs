﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NE_Entities : DbContext
    {
        public NE_Entities()
            : base("name=NE_Entities")
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
        public virtual DbSet<NE_EncabezadoChat> NE_EncabezadoChat { get; set; }
        public virtual DbSet<NE_FAQS> NE_FAQS { get; set; }
        public virtual DbSet<NE_Marca> NE_Marca { get; set; }
        public virtual DbSet<NE_Producto> NE_Producto { get; set; }
        public virtual DbSet<NE_ProductoImagen> NE_ProductoImagen { get; set; }
        public virtual DbSet<NE_Rol> NE_Rol { get; set; }
        public virtual DbSet<NE_Sexo> NE_Sexo { get; set; }
        public virtual DbSet<NE_Template> NE_Template { get; set; }
        public virtual DbSet<NE_Transmision> NE_Transmision { get; set; }
        public virtual DbSet<NE_Usuario> NE_Usuario { get; set; }
        public virtual DbSet<NE_Vehiculo> NE_Vehiculo { get; set; }
        public virtual DbSet<NE_VehiculoImagen> NE_VehiculoImagen { get; set; }
        public virtual DbSet<NE_Encuesta> NE_Encuesta { get; set; }
        public virtual DbSet<NE_Visita> NE_Visita { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SERVICIO.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AcademiaSistemasEntities : DbContext
    {
        public AcademiaSistemasEntities()
            : base("name=AcademiaSistemasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Asistencia> Asistencias { get; set; }
        public virtual DbSet<Aula> Aulas { get; set; }
        public virtual DbSet<Calificacion> Calificacions { get; set; }
        public virtual DbSet<CategoriaCurso> CategoriaCursoes { get; set; }
        public virtual DbSet<Certificado> Certificadoes { get; set; }
        public virtual DbSet<Curso> Cursoes { get; set; }
        public virtual DbSet<DetallePago> DetallePagoes { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Examan> Examen { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<Inscripcion> Inscripcions { get; set; }
        public virtual DbSet<Pago> Pagoes { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }
        public virtual DbSet<Sancion> Sancions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Perfil> Perfils { get; set; }
        public virtual DbSet<Usuario_Perfil> Usuario_Perfil { get; set; }
    }
}

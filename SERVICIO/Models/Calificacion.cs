//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Calificacion
    {
        public int Id { get; set; }
        public decimal Nota { get; set; }
        public System.DateTime FechaCalificacion { get; set; }
        public Nullable<int> IdEstudiante { get; set; }
        public Nullable<int> IdCurso { get; set; }
    
        public virtual Estudiante Estudiante { get; set; }
        public virtual Curso Curso { get; set; }
    }
}

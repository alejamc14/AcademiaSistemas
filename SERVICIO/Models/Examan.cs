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
    
    public partial class Examan
    {
        public int Id { get; set; }
        public System.DateTime FechaExamen { get; set; }
        public int Duracion { get; set; }
        public decimal NotaMaxima { get; set; }
        public Nullable<int> IdCurso { get; set; }
    
        public virtual Curso Curso { get; set; }
    }
}

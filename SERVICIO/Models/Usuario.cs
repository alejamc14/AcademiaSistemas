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
    
    public partial class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Salt { get; set; }
        public Nullable<int> IdEstudiante { get; set; }
        public Nullable<int> IdProfesor { get; set; }
    
        public virtual Estudiante Estudiante { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}
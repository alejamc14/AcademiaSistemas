//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
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

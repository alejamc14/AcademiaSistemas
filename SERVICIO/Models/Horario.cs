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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Horario
    {
        public int Id { get; set; }
        public string DiaSemana { get; set; }
        public System.TimeSpan HoraInicio { get; set; }
        public System.TimeSpan HoraFin { get; set; }
        public Nullable<int> IdCurso { get; set; }
        public Nullable<int> IdAula { get; set; }

        [JsonIgnore]
        public virtual Aula Aula { get; set; }

        [JsonIgnore]
        public virtual Curso Curso { get; set; }
    }
}

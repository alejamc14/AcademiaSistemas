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
    
    public partial class DetallePago
    {
        public int Id { get; set; }
        public Nullable<int> IdPago { get; set; }
        public Nullable<int> IdCurso { get; set; }
        public int ValorUnitario { get; set; }
    
        public virtual Curso Curso { get; set; }
        public virtual Pago Pago { get; set; }
    }
}

using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVICIO.Clases
{
    public class clsPerfil
    {
        AcademiaSistemasEntities1 academiaSistemasEntities1 = new AcademiaSistemasEntities1();
        public Perfil perfil { get; set; }
        public IQueryable LlenarCombo()
        {
            return from P in academiaSistemasEntities1.Set<Perfil>()
                   select new
                   {
                       Codigo = P.Id,
                       Nombre = P.Nombre
                   };
        }
    }
}

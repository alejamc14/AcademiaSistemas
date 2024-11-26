using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVICIO.Clases
{
    public class clsCategoriaCurso
    {
        private AcademiaSistemasEntities1 academiaSistemasEntities1 = new AcademiaSistemasEntities1();
        public CategoriaCurso categoriaCurso { get; set; }

        public IQueryable LlenarCombo()
        {
            //return dbAcademia.CategoriaCursoes.OrderBy(t => t.Nombre).ToList();
            return from CC in academiaSistemasEntities1.Set<CategoriaCurso>()
                   select new
                   {
                       Codigo = CC.IdCategoria,
                       Nombre = CC.Nombre
                   };


        }
    }
}
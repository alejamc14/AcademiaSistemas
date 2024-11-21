using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SERVICIO.Clases
{
    public class clsExamen
    {
        private AcademiaSistemasEntities dbAcademia = new AcademiaSistemasEntities();

        public Examan examen { get; set; }

        public string Insertar()
        {
            try
            {
                dbAcademia.Examen.Add(examen);
                dbAcademia.SaveChanges();
                return "Se grabó el examen: " + examen.Descripcion;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Examan _examen = Consultar(examen.Id);
                if (_examen != null)
                {
                    dbAcademia.Examen.AddOrUpdate(examen);
                    dbAcademia.SaveChanges();
                    return "Se actualizaron los datos del examen " + examen.Descripcion;

                }
                else
                {
                    return "El codigo del examen que se quiere actualizar, no existe en la base de datos";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {
            try
            {
                Examan _examen = Consultar(examen.Id);
                if (_examen != null)
                {
                    dbAcademia.Examen.Remove(_examen);
                    dbAcademia.SaveChanges();
                    return "Se eliminaron los datos del examen " + examen.Descripcion;

                }
                else
                {
                    return "El codigo del examen que se quiere eliminar, no existe en la base de datos";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public Examan Consultar(int id)
        {
            return dbAcademia.Examen.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable LlenarTabla()
        {
            return from E in dbAcademia.Set<Examan>()
                   orderby E.FechaExamen
                   select new
                   {
                       Id = E.Id,
                       Fecha = E.FechaExamen,
                       Duración = E.Duracion,
                       Curso = E.IdCurso,
                       Descripción= E.Descripcion,
                       Nota_Maxima = E.NotaMaxima,
                   };
        }
    }
}
using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace SERVICIO.Clases
{
    public class clsCalificacion
    {
        AcademiaSistemasEntities dbAcademia = new AcademiaSistemasEntities();

        public Calificacion calificacion { get; set; }

        public string Insertar()
        {
            try
            {
                dbAcademia.Calificacions.Add(calificacion);
                dbAcademia.SaveChanges();
                return $"Se grabó la calificación con ID: {calificacion.Id} del estudiante {calificacion.IdEstudiante} proveniente del curso {calificacion.IdCurso} con una nota de {calificacion.Nota}."; 
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
                Calificacion _calificacion = Consultar(calificacion.Id);
                if (_calificacion != null)
                {
                    dbAcademia.Calificacions.AddOrUpdate(calificacion);
                    dbAcademia.SaveChanges();
                    return $"Se actualizaron los datos de la calificación con ID: {calificacion.Id} del estudiante {calificacion.IdEstudiante}.";
                }
                else
                {
                    return "El ID de la calificación no existe.";
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
                Calificacion _calificacion = Consultar(calificacion.Id);
                if (_calificacion != null)
                {
                    dbAcademia.Calificacions.Remove(_calificacion);
                    dbAcademia.SaveChanges();
                    return $"Se eliminó la calificación con ID: {calificacion.Id} del estudiante {calificacion.IdEstudiante}.";
                }
                else
                {
                    return "La calificación no existe en la base de datos.";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Calificacion Consultar(int ID)
        {
            return dbAcademia.Calificacions.FirstOrDefault(c => c.Id == ID);
        }

        public IQueryable LlenarTabla()
        {
            return from C in dbAcademia.Set<Calificacion>()
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEditar\" class=\"btn-block btn-dark\" onclick=\"Editar('" + C.Id + "','" + C.IdEstudiante + "', '" + 
                                C.IdCurso + "', '" + C.Nota + "', '" + C.FechaCalificacion + "')\">Edit</button>",
                       ID_Calificación = C.Id,
                       ID_Estudiante = C.IdEstudiante,
                       Nombre_Estudiante = C.Estudiante.Nombre,
                       Apellido_Estudiante = C.Estudiante.Apellido,
                       Nombre_Curso = C.Curso.Nombre,
                       C.Nota,
                       C.FechaCalificacion
                   };
        }

        public IQueryable ObtenerEstudiantes()
        {
            return from E in new AcademiaSistemasEntities().Estudiantes
                   orderby E.Nombre, E.Apellido
                   select new
                   {
                       Codigo = E.Id,
                       Nombre = E.Nombre + " " + E.Apellido
                   };
        }

        public IQueryable ObtenerCurso()
        {
            return from C in new AcademiaSistemasEntities().Cursoes
                   orderby C.Nombre
                   select new
                   {
                       Codigo = C.Id,
                       Nombre = C.Nombre
                   };
        }
    }
}
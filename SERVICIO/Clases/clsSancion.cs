using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace SERVICIO.Clases
{
    public class clsSancion
    {
        AcademiaSistemasEntities dbAcademia = new AcademiaSistemasEntities();

        public Sancion sancion { get; set; }

        public string Insertar()
        {
            try
            {
                dbAcademia.Sancions.Add(sancion);
                dbAcademia.SaveChanges();
                return $"Se grabó la sanción para el estudiante con ID: {sancion.IdEstudiante}.";
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
                Sancion _sancion = Consultar(sancion.Id);
                if (_sancion != null)
                {
                    dbAcademia.Sancions.AddOrUpdate(sancion);
                    dbAcademia.SaveChanges();
                    return $"Se actualizaron los datos de la sanción con ID: {sancion.Id} del estudiante con ID: {sancion.IdEstudiante}";
                }
                else
                {
                    return "El ID de la sanción no existe.";
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
                Sancion _sancion = Consultar(sancion.Id);
                if (_sancion != null)
                {
                    dbAcademia.Sancions.Remove(_sancion);
                    dbAcademia.SaveChanges();
                    return $"Se eliminó la sanción con ID: {sancion.Id} del estudiante con ID: {sancion.IdEstudiante}.";
                }
                else
                {
                    return "La sanción no existe en la base de datos.";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Sancion Consultar(int ID)
        {
            return dbAcademia.Sancions.FirstOrDefault(s => s.Id == ID);
        }

        public IQueryable LlenarTabla()
        {
            return from S in dbAcademia.Set<Sancion>()
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEditar\" class=\"btn-block btn-dark\" onclick=\"Editar('" + S.Id + "','" + S.IdEstudiante + "', '" +
                                S.Motivo + "', '" + S.Duracion + "', '" + S.FechaSancion + "')\">Edit</button>",
                       Id = S.Id,
                       IdEstudiante = S.IdEstudiante,
                       Nombre_Estudiante = S.Estudiante.Nombre,
                       Apellido_Estudiante = S.Estudiante.Apellido,
                       Motivo = S.Motivo,
                       FechaSancion = S.FechaSancion,
                       Duracion = S.Duracion
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
    }
}
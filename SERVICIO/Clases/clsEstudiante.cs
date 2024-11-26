using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SERVICIO.Models;
using System.Web.Http.Cors;
using System.Data.Entity.Migrations;

namespace SERVICIO.Clases
{
    public class clsEstudiante
    {
        AcademiaSistemasEntities dbAcademia = new AcademiaSistemasEntities();

        public Estudiante estudiante { get; set; }

        public string Insertar()
        {
            try
            {
                dbAcademia.Estudiantes.Add(estudiante);
                dbAcademia.SaveChanges();
                return "Se grabó el estudiante " + estudiante.Nombre + " " + estudiante.Apellido;
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
                Estudiante _estudiante = Consultar(estudiante.Id);
                if (_estudiante != null)
                {
                    dbAcademia.Estudiantes.AddOrUpdate(estudiante);
                    dbAcademia.SaveChanges();
                    return "Se actualizaron los datos del estudiante con ID: " + estudiante.Id;
                }
                else
                {
                    return "El ID del estudiante no existe en la base de datos.";
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
                Estudiante _estudiante = Consultar(estudiante.Id);
                if (_estudiante != null)
                {
                    dbAcademia.Estudiantes.Remove(_estudiante);
                    dbAcademia.SaveChanges();
                    return "Se eliminó el estudiante: " + estudiante.Nombre + " " + estudiante.Apellido;
                }
                else
                {
                    return "El estudiante no existe en la base de datos.";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Estudiante Consultar(int ID)
        {
            return dbAcademia.Estudiantes.FirstOrDefault(e => e.Id == ID);
        }

        public IQueryable LlenarTabla()
        {
            return from E in dbAcademia.Set<Estudiante>()
                   orderby E.Nombre
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEditar\" class=\"btn-block btn-dark\" onclick=\"Editar('" + E.Id + "','" + E.Documento + "', '" +
                                E.Nombre + "', '" + E.Apellido + "', '" + E.FechaNacimiento + "', '" + E.Telefono + "', '" +
                                E.Direccion + "', '" + E.Correo + "')\">Edit</button>",
                       Id = E.Id,
                       Documento = E.Documento,
                       Nombre = E.Nombre,
                       Apellido = E.Apellido,
                       FechaNacimiento = E.FechaNacimiento,
                       Telefono = E.Telefono,
                       Direccion = E.Direccion,
                       Correo = E.Correo
                   };
        }
    }
}

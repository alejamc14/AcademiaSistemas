using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SERVICIO.Clases
{
    public class clsEstudiante
    {
        AcademiaSistemasEntities1 academiaSistemasEntities1 = new AcademiaSistemasEntities1();

        public Estudiante estudiante { get; set; }
        public string Insertar()
        {
            try
            {
                academiaSistemasEntities1.Estudiantes.Add(estudiante);
                academiaSistemasEntities1.SaveChanges();
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
                Estudiante _estudiante = Consultar(estudiante.Documento);
                if (_estudiante != null)
                {
                    academiaSistemasEntities1.Estudiantes.AddOrUpdate(estudiante);
                    academiaSistemasEntities1.SaveChanges();
                    return "Se actualizaron los datos del estudiante con documento: " + estudiante.Documento;
                }
                else
                {
                    return "El documento del estudiante no existe en la base de datos.";
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
                Estudiante _estudiante = Consultar(estudiante.Documento);
                if (_estudiante != null)
                {
                    academiaSistemasEntities1.Estudiantes.Remove(_estudiante);
                    academiaSistemasEntities1.SaveChanges();
                    return "Se eliminó el estudiante: " + estudiante.Nombre + " " + estudiante.Apellido;
                }
                else
                {
                    return "El cliente no existe en la base de datos.";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Estudiante Consultar(string Documento)
        {
            return academiaSistemasEntities1.Estudiantes.FirstOrDefault(e => e.Documento == Documento);
        }

        public IQueryable ConsultarEstudiante(string Documento)
        {
            return from E in academiaSistemasEntities1.Set<Estudiante>()
                   where E.Documento == Documento
                   select new
                   {
                       Estudiante = E.Nombre + " " + E.Apellido
                   };
        }
        public IQueryable LlenarTabla()
        {
            return from E in academiaSistemasEntities1.Set<Estudiante>()
                   orderby E.Nombre
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEditar\" class=\"btn btn-success\" onclick=\"EditarEstudiante('" + E.Documento + "' , '" + E.Nombre + "', '" + E.Apellido + "', '"+ E.FechaNacimiento +"', '"+ E.Telefono +"', " +
                       " '"+ E.Direccion +"', '"+ E.Correo +"')\"><i class=\"bi bi-pencil-square\"></i></button>",
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
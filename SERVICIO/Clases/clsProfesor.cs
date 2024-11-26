using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SERVICIO.Clases
{
    public class clsProfesor
    {
        AcademiaSistemasEntities1 academiaSistemasEntities1 = new AcademiaSistemasEntities1();
        public Profesor profesor { get; set; }
        public string Insertar()
        {
            try
            {
                academiaSistemasEntities1.Profesors.Add(profesor);
                academiaSistemasEntities1.SaveChanges();
                return "Se grabó el profesor " + profesor.Nombre + " " + profesor.Apellido;
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
                Profesor _profesor = Consultar(profesor.Documento);
                if (_profesor != null)
                {
                    academiaSistemasEntities1.Profesors.AddOrUpdate(profesor);
                    academiaSistemasEntities1.SaveChanges();
                    return "Se actualizaron los datos del profesor con documento: " + profesor.Documento;
                }
                else
                {
                    return "El documento del profesor no existe en la base de datos.";
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
                Profesor _profesor = Consultar(profesor.Documento);
                if (_profesor != null)
                {
                    academiaSistemasEntities1.Profesors.Remove(_profesor);
                    academiaSistemasEntities1.SaveChanges();
                    return "Se eliminó el profesor: " + profesor.Nombre + " " + profesor.Apellido;
                }
                else
                {
                    return "El profesor no existe en la base de datos.";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Profesor Consultar(string Documento)
        {
            return academiaSistemasEntities1.Profesors.FirstOrDefault(e => e.Documento == Documento);
        }
        public IQueryable ConsultarProfesor(string Documento)
        {
            return from P in academiaSistemasEntities1.Set<Profesor>()
                   where P.Documento == Documento
                   select new
                   {
                       Profesor = P.Nombre + " " + P.Apellido
                   };
        }

        public IQueryable LlenarTabla()
        {
            return from P in academiaSistemasEntities1.Set<Profesor>()
                   orderby P.Nombre
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEditar\" class=\"btn btn-success\" onclick=\"EditarProfesor('" + P.Documento + "' , '" + P.Nombre + "', '" + P.Apellido + "', '" + P.Especialidad + "', '" + P.Telefono + "', " +
                       " '" + P.Correo + "')\"><i class=\"bi bi-pencil-square\"></i></button>",
                       Id = P.Id,
                       Documento = P.Documento,
                       Nombre = P.Nombre,
                       Apellido = P.Apellido,
                       Especialidad = P.Especialidad,
                       Telefono = P.Telefono,
                       Correo = P.Correo
                   };
        }
        public IQueryable LlenarProfesor()
        {
            return from P in academiaSistemasEntities1.Set<Profesor>()
                   select new
                   {
                       Codigo = P.Id,
                       Nombre = P.Nombre + " " + P.Apellido,
                   };
        }
    }
}
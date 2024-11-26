using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace SERVICIO.Clases
{
    public class clsProfesor
    {
        AcademiaSistemasEntities dbAcademia = new AcademiaSistemasEntities();

        public Profesor profesor { get; set; }

        public string Insertar()
        {
            try
            {
                dbAcademia.Profesors.Add(profesor);
                dbAcademia.SaveChanges();
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
                Profesor _profesor = Consultar(profesor.Id);
                if (_profesor != null)
                {
                    dbAcademia.Profesors.AddOrUpdate(profesor);
                    dbAcademia.SaveChanges();
                    return $"Se actualizaron los datos del profesor con ID: {profesor.Id}";
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

        public string Eliminar()
        {
            try
            {
                Profesor _profesor = Consultar(profesor.Id);
                if (_profesor != null)
                {
                    dbAcademia.Profesors.Remove(_profesor);
                    dbAcademia.SaveChanges();
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

        public Profesor Consultar(int ID)
        {
            return dbAcademia.Profesors.FirstOrDefault(e => e.Id == ID);
        }

        public IQueryable LlenarTabla()
        {
            return from P in dbAcademia.Set<Profesor>()
                   orderby P.Nombre
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEditar\" class=\"btn-block btn-dark\" onclick=\"Editar('" + P.Id + "','" + P.Documento + "', '" +
                                P.Nombre + "', '" + P.Apellido + "', '" + P.Especialidad + "', '" + P.Telefono + "', '" + P.Correo + "')\">Edit</button>",
                       Id = P.Id,
                       Documento = P.Documento,
                       Nombre = P.Nombre,
                       Apellido = P.Apellido,
                       Especialidad = P.Especialidad,
                       Telefono = P.Telefono,
                       Correo = P.Correo
                   };
        }

    }
}
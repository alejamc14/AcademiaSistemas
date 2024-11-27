using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SERVICIO.Clases
{
    public class clsAsistencia
    {
        AcademiaSistemasEntities academiaSistemasEntities1 = new AcademiaSistemasEntities();

        public Asistencia asistencia { get; set; }

        public string Insertar()
        {
            try
            {
                academiaSistemasEntities1.Asistencias.Add(asistencia);
                academiaSistemasEntities1.SaveChanges();
                return "Se grabo la Asistencia con exito";
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
                academiaSistemasEntities1.Asistencias.AddOrUpdate(asistencia);
                academiaSistemasEntities1.SaveChanges();
                return $"Se actualizaron los datos de la inscripción con {asistencia.Id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {
            Asistencia _asistencia = Consultar(asistencia.Id);
            academiaSistemasEntities1.Asistencias.Remove(_asistencia);
            academiaSistemasEntities1.SaveChanges();
            return $"Se eliminó la inscripción {asistencia.Id}";
        }
        public Asistencia Consultar(int Id)
        {
            return academiaSistemasEntities1.Asistencias.FirstOrDefault(c => c.Id == Id);
        }
        public IQueryable LlenarTabla()
        {
            return from A in academiaSistemasEntities1.Asistencias
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEditar\" class=\"btn btn-success\" onclick=\"EditarAsistencia('"+ A.FechaAsistencia +"')\"><i class=\"bi bi-pencil-square\"></i></button>",
                       Id = A.Id,
                       FechaAsistencia = A.FechaAsistencia,
                       IdEstudiante = A.IdEstudiante,
                       IdCurso = A.IdCurso
                   };
        }
    }
}
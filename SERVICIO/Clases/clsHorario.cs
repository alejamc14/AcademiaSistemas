using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace SERVICIO.Clases
{
    public class clsHorario
    {
        AcademiaSistemasEntities1 academiaSistemasEntities1 = new AcademiaSistemasEntities1();

        public Horario horario { get; set; }

        public string Insertar()
        {
            try
            {
                academiaSistemasEntities1.Horarios.Add(horario);
                academiaSistemasEntities1.SaveChanges();
                return "Se grabo el Horario con exito";
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
                academiaSistemasEntities1.Horarios.AddOrUpdate(horario);
                academiaSistemasEntities1.SaveChanges();
                return $"Se actualizaron los datos del Horario {horario.Id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {
            Horario _horario = Consultar(horario.Id);
            academiaSistemasEntities1.Horarios.Remove(_horario);
            academiaSistemasEntities1.SaveChanges();
            return $"Se eliminó el horario {horario.Id}";
        }
        public Horario Consultar(int Id)
        {
            return academiaSistemasEntities1.Horarios.FirstOrDefault(c => c.Id == Id);
        }
        public IQueryable LlenarTabla()
        {
            return from H in academiaSistemasEntities1.Horarios
                   //join C in academiaSistemasEntities1.Set<Curso>()
                   //on H.IdCurso equals C.Id
                   //join AU in academiaSistemasEntities1.Set<Aula>()
                   //on H.IdAula equals AU.Id
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEditar\" class=\"btn btn-success\" onclick=\"EditarHorario('" + H.DiaSemana +"' , '"+ H.HoraInicio +"', '"+ H.HoraFin +"')\"><i class=\"bi bi-pencil-square\"></i></button>",
                       Id = H.Id,
                       DiaSemana = H.DiaSemana,
                       HoraInicio = H.HoraInicio,
                       HoraFin = H.HoraFin
                   };
        }
    }
}
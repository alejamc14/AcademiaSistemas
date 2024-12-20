﻿using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace SERVICIO.Clases
{
    public class clsInscripcion
    {
        AcademiaSistemasEntities academiaSistemasEntities1 = new AcademiaSistemasEntities();
        public Inscripcion inscripcion { get; set; }

        public string Insertar()
        {
            try
            {
                academiaSistemasEntities1.Inscripcions.Add(inscripcion);
                academiaSistemasEntities1.SaveChanges();
                return "Se grabo la Inscripción con exito";
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
                academiaSistemasEntities1.Inscripcions.AddOrUpdate(inscripcion);
                academiaSistemasEntities1.SaveChanges();
                return $"Se actualizaron los datos de la inscripción con {inscripcion.Id}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {
            Inscripcion _inscripcion = Consultar(inscripcion.Id);
            academiaSistemasEntities1.Inscripcions.Remove(_inscripcion);
            academiaSistemasEntities1.SaveChanges();
            return $"Se eliminó la inscripción {inscripcion.Id}";
        }
        public Inscripcion Consultar(int Id)
        {
            return academiaSistemasEntities1.Inscripcions.FirstOrDefault(c => c.Id == Id);
        }
        public IQueryable LlenarTabla()
        {
            return from I in academiaSistemasEntities1.Inscripcions
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEditar\" class=\"btn btn-success\" onclick=\"EditarInscripcion('"+ I.FechaInscripcion +"')\"><i class=\"bi bi-pencil-square\"></i></button>",
                       Id = I.Id,
                       FechaInscripcion = I.FechaInscripcion,
                       IdEstudiante = I.IdEstudiante,
                       IdCurso = I.IdCurso
                   };
        }
    }
}
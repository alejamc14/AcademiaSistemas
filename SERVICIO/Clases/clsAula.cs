using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SERVICIO.Clases
{
    public class clsAula
    {
        private AcademiaSistemasEntities1 dbAcademia = new AcademiaSistemasEntities1();
        public Aula aula {  get; set; }

        public string Insertar()
        {
            try
            {
                dbAcademia.Aulas.Add(aula);
                dbAcademia.SaveChanges();
                return "Se grabó el Aula: " + aula.Nombre;

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
                
                Aula _aula= Consultar(aula.Id);
                if (_aula != null)
                {
                    dbAcademia.Aulas.AddOrUpdate(aula);
                    dbAcademia.SaveChanges();
                    return "Se actualizaron los datos del aula: " + aula.Nombre;

                }
                else
                {
                    return "El codigo del aula que se quiere actualizar, no existe en la base de datos";
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
                Aula _aula = Consultar(aula.Id);
                if (_aula != null)
                {
                    dbAcademia.Aulas.Remove(_aula);
                    dbAcademia.SaveChanges();
                    return "Se elimino el aula: " + _aula.Nombre;
                }
                else
                {
                    return "El id no existe en la base de datos";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Aula Consultar(int id)
        { 
            return dbAcademia.Aulas.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable llenarTabla()
        {
            return from C in dbAcademia.Set<Aula>()
                   orderby C.Nombre
                   select new
                   {
                       Id_Aula = C.Id,
                       Nombre = C.Nombre,
                       Capacidad = C.Capacidad,
                       Descripción = C.Descripcion
                   };

        }
        public IQueryable listarAulas()
        {
            return from A in dbAcademia.Set<Aula>()
                   orderby A.Nombre
                   select new
                   {
                       Codigo = A.Id,
                       Nombre = A.Nombre
                   };

        }


    }
}
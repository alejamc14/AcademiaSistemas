using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SERVICIO.Clases
{
    public class clsCurso
    {
        private AcademiaSistemasEntities dbAcademia = new AcademiaSistemasEntities();

        public Curso curso { get; set; }

        public string Insertar()
        {
            try
            {
                dbAcademia.Cursoes.Add(curso);
                dbAcademia.SaveChanges();
                return "Se grabó el curso: " + curso.Nombre;

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
                Curso _curso = Consultar(curso.Id);
                if (_curso != null)
                {
                    dbAcademia.Cursoes.AddOrUpdate(curso);
                    dbAcademia.SaveChanges();
                    return "Se actualizaron los datos del curso: " + curso.Nombre;

                }
                else
                {
                    return "El codigo del curso que se quiere actualizar, no existe en la base de datos";
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
                Curso _curso = Consultar(curso.Id);
                if (_curso != null)
                {
                    dbAcademia.Cursoes.Remove(_curso);
                    dbAcademia.SaveChanges();
                    return "Se elimino el curso: " + _curso.Nombre;
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
        public Curso Consultar(int codigo)
        {
            return dbAcademia.Cursoes.FirstOrDefault(x => x.Id == codigo);
        }

        public IQueryable llenarTabla()
        {
            return from C in dbAcademia.Set<Curso>()
                   join CC in dbAcademia.Set<CategoriaCurso>()
                   on C.IdCategoria equals CC.IdCategoria
                   orderby C.Nombre, CC.Nombre
                   select new
                   {
                       Id_Categoria = CC.IdCategoria,
                       Categoria = CC.Nombre,
                       Id_Curso = C.Id,
                       Curso = C.Nombre,
                       Descripcion = C.Descripcion,
                       Hora = C.Hora,
                       Id_Profesor = C.IdProfesor,
                       Precio = C.Precio
                   };

        }
    }
}
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
        AcademiaSistemasEntities1 academiaSistemasEntities1 = new AcademiaSistemasEntities1();
        public Curso curso { get; set; }

        public string Insertar()
        {
            try
            {
                academiaSistemasEntities1.Cursoes.Add(curso);
                academiaSistemasEntities1.SaveChanges();
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
                    academiaSistemasEntities1.Cursoes.AddOrUpdate(curso);
                    academiaSistemasEntities1.SaveChanges();
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
                    academiaSistemasEntities1.Cursoes.Remove(_curso);
                    academiaSistemasEntities1.SaveChanges();
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
        public Curso Consultar(int Codigo)
        {
            return academiaSistemasEntities1.Cursoes.FirstOrDefault(c => c.Id == Codigo);
        }
        public IQueryable llenarTabla()
        {
            return from C in academiaSistemasEntities1.Set<Curso>()
                   join CC in academiaSistemasEntities1.Set<CategoriaCurso>()
                   on C.IdCategoria equals CC.IdCategoria
                   join P in academiaSistemasEntities1.Set<Profesor>()
                   on C.IdProfesor equals P.Id
                   orderby C.Nombre, CC.Nombre
                   select new
                   {
                       Id_Categoria = CC.IdCategoria,
                       Categoria = CC.Nombre,
                       Id_Curso = C.Id,
                       Curso = C.Nombre,
                       Descripcion = C.Descripcion,
                       Hora = C.Hora,
                       Profesor = P.Nombre,
                       Precio = C.Precio
                   };

        }

        public IQueryable listarCursosXCategoriaCursos(int CategoriaCurso)
        {
            return from C in academiaSistemasEntities1.Set<Curso>()
                   join CC in academiaSistemasEntities1.Set<CategoriaCurso>()
                   on C.IdCategoria equals CC.IdCategoria
                   where CC.IdCategoria == CategoriaCurso
                   orderby C.Nombre, CC.Nombre
                   select new
                   {
                       Codigo = C.Id + "|" + C.Precio,
                       Nombre = C.Nombre
                   };

        }
        public IQueryable listarCursos()
        {
            return from C in academiaSistemasEntities1.Set<Curso>()
                   orderby C.Nombre
                   select new
                   {
                       Codigo = C.Id,
                       Nombre = C.Nombre
                   };

        }
    }
}
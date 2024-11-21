using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SERVICIO.Clases
{
    public class clsCertificado
    {
        private AcademiaSistemasEntities dbAcademia = new AcademiaSistemasEntities();

        public Certificado certificado { get; set; }

        public string Insertar() 
        {
            try
            {
                dbAcademia.Certificadoes.Add(certificado);
                dbAcademia.SaveChanges();
                return "Se grabó: " + certificado.NombreCertificado;

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

                Certificado _certificado = Consultar(certificado.Id);
                if (_certificado != null)
                {
                    dbAcademia.Certificadoes.AddOrUpdate(certificado);
                    dbAcademia.SaveChanges();
                    return "Se actualizaron los datos del certificado: " + certificado.NombreCertificado;

                }
                else
                {
                    return "El codigo del certificado que se quiere actualizar, no existe en la base de datos";
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

                Certificado _certificado = Consultar(certificado.Id);
                if (_certificado != null)
                {
                    dbAcademia.Certificadoes.Remove(certificado);
                    dbAcademia.SaveChanges();
                    return "Se elimino el certificado: " + certificado.NombreCertificado;

                }
                else
                {
                    return "El codigo del certificado que se quiere eliminar, no existe en la base de datos";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Certificado Consultar(int id)
        {
            return dbAcademia.Certificadoes.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable llenarTabla()
        {
            return from C in dbAcademia.Set<Certificado>()
                   orderby C.NombreCertificado
                   select new
                   {
                       Id_Aula = C.Id,
                       Nombre = C.NombreCertificado,
                       Fecha = C.FechaCertificacion,
                       Estudiante = C.IdEstudiante,
                       Curso= C.IdCurso,
                   };

        }
    }
}
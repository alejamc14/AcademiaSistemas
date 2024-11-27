using SERVICIO.Clases;
using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SERVICIO.Controllers
{
    [EnableCors(origins: "http://localhost:64868", headers: "*", methods: "*")]
    [RoutePrefix("api/Profesor")]
    //[Authorize]
    public class ProfesoresController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Profesor profesor)
        {
            clsProfesor _profesor = new clsProfesor();
            _profesor.profesor = profesor;
            return _profesor.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Profesor profesor)
        {
            clsProfesor _profesor = new clsProfesor();
            _profesor.profesor = profesor;
            return _profesor.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Profesor profesor)
        {
            clsProfesor _profesor = new clsProfesor();
            _profesor.profesor = profesor;
            return _profesor.Eliminar();
        }

        [HttpGet]
        [Route("ConsultarXDocumento")]
        public Profesor ConsultarXDocumento(string Documento)
        {
            clsProfesor _profesor = new clsProfesor();
            return _profesor.Consultar(Documento);
        }
        
        [HttpGet]
        [Route("ConsultarProfesor")]
        public IQueryable ConsultarProfesor(string Documento)
        {
            clsProfesor _profesor = new clsProfesor();
            return _profesor.ConsultarProfesor(Documento);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsProfesor _profesor = new clsProfesor();
            return _profesor.LlenarTabla();
        }
        [HttpGet]
        [Route("LlenarProfesor")]
        public IQueryable LlenarProfesor()
        {
            clsProfesor _profesor = new clsProfesor();
            return _profesor.LlenarProfesor();
        }
    }
}
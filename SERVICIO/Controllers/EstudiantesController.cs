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
    [RoutePrefix("api/Estudiantes")]
    [EnableCors(origins: "https://localhost:44387", headers: "*", methods: "*")]
    public class EstudiantesController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Estudiante estudiante)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            _estudiante.estudiante = estudiante;
            return _estudiante.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Estudiante estudiante)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            _estudiante.estudiante = estudiante;
            return _estudiante.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Estudiante estudiante)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            _estudiante.estudiante = estudiante;
            return _estudiante.Eliminar();
        }

        [HttpGet]
        [Route("ConsultarXID")]
        public Estudiante ConsultarXID(int Id)
        {
            clsEstudiante _estudiante = new clsEstudiante();
            return _estudiante.Consultar(Id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsEstudiante _estudiante = new clsEstudiante();
            return _estudiante.LlenarTabla();
        }
    }
}
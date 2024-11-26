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
    [RoutePrefix("api/Profesors")]
    [EnableCors(origins: "https://localhost:44387", headers: "*", methods: "*")]
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
        [Route("ConsultarXID")]
        public Profesor ConsultarXID(int Id)
        {
            clsProfesor _profesor = new clsProfesor();
            return _profesor.Consultar(Id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsProfesor _profesor = new clsProfesor();
            return _profesor.LlenarTabla();
        }
    }
}
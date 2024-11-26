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
    [RoutePrefix("api/Calificacions")]
    [EnableCors(origins: "https://localhost:44387", headers: "*", methods: "*")]
    public class CalificacionesController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Calificacion calificacion)
        {
            clsCalificacion _calificacion = new clsCalificacion();
            _calificacion.calificacion = calificacion;
            return _calificacion.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Calificacion calificacion)
        {
            clsCalificacion _calificacion = new clsCalificacion();
            _calificacion.calificacion = calificacion;
            return _calificacion.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Calificacion calificacion)
        {
            clsCalificacion _calificacion = new clsCalificacion();
            _calificacion.calificacion = calificacion;
            return _calificacion.Eliminar();
        }

        [HttpGet]
        [Route("ConsultarXID")]
        public Calificacion ConsultarXID(int Id)
        {
            clsCalificacion _calificacion = new clsCalificacion();
            return _calificacion.Consultar(Id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsCalificacion _calificacion = new clsCalificacion();
            return _calificacion.LlenarTabla();
        }

        [HttpGet]
        [Route("ObtenerEstudiantes")]
        public IQueryable ObtenerEstudiantes()
        {
            clsCalificacion _calificacion = new clsCalificacion();
            return _calificacion.ObtenerEstudiantes();
        }

        [HttpGet]
        [Route("ObtenerCurso")]
        public IQueryable ObtenerCurso()
        {
            clsCalificacion _calificacion = new clsCalificacion();
            return _calificacion.ObtenerCurso();
        }
    }
}
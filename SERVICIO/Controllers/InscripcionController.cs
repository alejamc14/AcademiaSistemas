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
    [RoutePrefix("api/Inscripcion")]
    public class InscripcionController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Inscripcion inscripcion)
        {
            clsInscripcion _inscripcion = new clsInscripcion();
            _inscripcion.inscripcion = inscripcion;
            return _inscripcion.Insertar();
        }
        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsInscripcion _inscripcion = new clsInscripcion();
            return _inscripcion.LlenarTabla();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Inscripcion inscripcion)
        {
            clsInscripcion _inscripcion = new clsInscripcion();
            _inscripcion.inscripcion = inscripcion;
            return _inscripcion.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Inscripcion inscripcion)
        {
            clsInscripcion _inscripcion = new clsInscripcion();
            _inscripcion.inscripcion = inscripcion;
            return _inscripcion.Eliminar();
        }
        [HttpGet]
        [Route("Consultar")]
        public Inscripcion ConsultarDocumento(int Id)
        {
            clsInscripcion _inscripcion = new clsInscripcion();
            return _inscripcion.Consultar(Id);
        }
    }
}
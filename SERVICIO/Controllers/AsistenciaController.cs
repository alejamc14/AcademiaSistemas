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
    [RoutePrefix("api/Asistencia")]
    [Authorize]
    public class AsistenciaController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Asistencia asistencia)
        {
            clsAsistencia _asistencia = new clsAsistencia();
            _asistencia.asistencia = asistencia;
            return _asistencia.Insertar();
        }
        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsAsistencia _asistencia = new clsAsistencia();
            return _asistencia.LlenarTabla();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Asistencia asistencia)
        {
            clsAsistencia _asistencia = new clsAsistencia();
            _asistencia.asistencia = asistencia;
            return _asistencia.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Asistencia asistencia)
        {
            clsAsistencia _asistencia = new clsAsistencia();
            _asistencia.asistencia = asistencia;
            return _asistencia.Eliminar();
        }
        [HttpGet]
        [Route("Consultar")]
        public Asistencia Consultar(int Id)
        {
            clsAsistencia _asistencia = new clsAsistencia();
            return _asistencia.Consultar(Id);
        }
    }
}
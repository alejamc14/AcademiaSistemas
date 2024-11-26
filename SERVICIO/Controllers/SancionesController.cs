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
    [RoutePrefix("api/Sancions")]
    [EnableCors(origins: "https://localhost:44387", headers: "*", methods: "*")]
    public class SancionesController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Sancion sancion)
        {
            clsSancion _sancion = new clsSancion();
            _sancion.sancion = sancion;
            return _sancion.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Sancion sancion)
        {
            clsSancion _sancion = new clsSancion();
            _sancion.sancion = sancion;
            return _sancion.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Sancion sancion)
        {
            clsSancion _sancion = new clsSancion();
            _sancion.sancion = sancion;
            return _sancion.Eliminar();
        }

        [HttpGet]
        [Route("ConsultarXID")]
        public Sancion ConsultarXID(int Id)
        {
            clsSancion _sancion = new clsSancion();
            return _sancion.Consultar(Id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsSancion _sancion = new clsSancion();
            return _sancion.LlenarTabla();
        }

        [HttpGet]
        [Route("ObtenerEstudiantes")]
        public IQueryable ObtenerEstudiantes()
        {
            clsSancion _sancion = new clsSancion();
            return _sancion.ObtenerEstudiantes();
        }
    }
}
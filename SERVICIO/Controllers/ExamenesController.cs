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
    [RoutePrefix("api/Examenes")]
    public class ExamenesController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Examan examen)
        {
            clsExamen _examen = new clsExamen();
            _examen.examen = examen;
            return _examen.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Examan examen)
        {
            clsExamen _examen = new clsExamen();
            _examen.examen = examen;
            return _examen.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Examan examen)
        {
            clsExamen _examen = new clsExamen();
            _examen.examen = examen;
            return _examen.Eliminar();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Examan ConsultarXId(int Id)
        {
            clsExamen _examen = new clsExamen();
            return _examen.Consultar(Id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsExamen _examen = new clsExamen();
            return _examen.LlenarTabla();
        }
    }
}
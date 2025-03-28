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
    [RoutePrefix("api/Aulas")]
    public class AulasController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Aula aula)
        {
            clsAula _aula = new clsAula();
            _aula.aula= aula;
            return _aula.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Aula aula)
        {
            clsAula _aula = new clsAula();
            _aula.aula = aula;
            return _aula.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Aula aula)
        {
            clsAula _aula = new clsAula();
            _aula.aula = aula;
            return _aula.Eliminar();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Aula ConsultarXId(int id)
        {
            clsAula _aula = new clsAula();
            return _aula.Consultar(id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsAula _aula = new clsAula();
            return _aula.llenarTabla();
        }
        
        [HttpGet]
        [Route("listarAulas")]
        public IQueryable listarAulas()
        {
            clsAula _aula = new clsAula();
            return _aula.listarAulas();
        }
    }
}
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
    [RoutePrefix("api/Horario")]
    [Authorize]
    public class HorarioController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Horario horario)
        {
            clsHorario _horario = new clsHorario();
            _horario.horario = horario;
            return _horario.Insertar();
        }
        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsHorario _horario = new clsHorario();
            return _horario.LlenarTabla();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Horario horario)
        {
            clsHorario _horario = new clsHorario();
            _horario.horario = horario;
            return _horario.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Horario horario)
        {
            clsHorario _horario = new clsHorario();
            _horario.horario = horario;
            return _horario.Eliminar();
        }
        [HttpGet]
        [Route("Consultar")]
        public Horario ConsultarDocumento(int Id)
        {
            clsHorario _horario = new clsHorario();
            return _horario.Consultar(Id);
        }
    }
}
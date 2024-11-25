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
    [RoutePrefix("api/Cursos")]
    public class CursosController : ApiController
    {
        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo()
        {
            clsCurso curso = new clsCurso();
            return curso.LlenarCombo();
        }

        [HttpGet]
        [Route("ConsultarXCodigo")]
        public Curso ConsultarXCodigo(int Codigo)
        {
            clsCurso curso = new clsCurso();
            return curso.Consultar(Codigo);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsCurso curso = new clsCurso();
            return curso.llenarTabla();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Curso Curso)
        {
            clsCurso curso = new clsCurso();
            curso.curso = Curso;
            return curso.Insertar();

        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Curso Curso)
        {
            clsCurso curso = new clsCurso();
            curso.curso = Curso;
            return curso.Actualizar();

        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Curso Curso)
        {
            clsCurso curso = new clsCurso();
            curso.curso = Curso;
            return curso.Eliminar();
        }
    }
}
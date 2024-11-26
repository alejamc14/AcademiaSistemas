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
    [Authorize]
    public class CursosController : ApiController
    {
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
        [HttpGet]
        [Route("ConsultarXCodigo")]
        public Curso ConsultarXCodigo(int Codigo)
        {
            clsCurso _curso = new clsCurso();
            return _curso.Consultar(Codigo);
        }
        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsCurso curso = new clsCurso();
            return curso.llenarTabla();
        }
        [HttpGet]
        [Route("listarCursosXCategoriaCursos")]
        public IQueryable listarCursosXCategoriaCursos(int CategoriaCurso)
        {
            clsCurso curso = new clsCurso();
            return curso.listarCursosXCategoriaCursos(CategoriaCurso);
        }
    }
}
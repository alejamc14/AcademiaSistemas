using SERVICIO.Clases;
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
    [RoutePrefix("api/CategoriaCursos")]
    public class CategoriaCursosController : ApiController
    {
        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo()
        {
            clsCategoriaCurso categoriaCurso = new clsCategoriaCurso();
            return categoriaCurso.LlenarCombo();
        }
    }
}
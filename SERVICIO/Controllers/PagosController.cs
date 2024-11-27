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
    [RoutePrefix("api/Pago")]
    [Authorize]
    public class PagosController : ApiController
    {
        [HttpPost]
        [Route("GrabarPago")]
        public string GrabarPago([FromBody] Pago pago)
        {
            clsPago _pago = new clsPago();
            _pago.pago = pago;
            return _pago.GrabarPago();
        }
        [HttpGet]
        [Route("ListarCursos")]
        public IQueryable ListarCursos(int NumeroPago)
        {
            clsPago _pago = new clsPago();
            return _pago.ListarCursos(NumeroPago);
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int NumeroDetalle)
        {
            clsPago _pago = new clsPago();
            return _pago.Eliminar(NumeroDetalle);
        }

    }
}
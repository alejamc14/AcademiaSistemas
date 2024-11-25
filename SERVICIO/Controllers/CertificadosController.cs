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

    [RoutePrefix("api/Certificados")]
    public class CertificadosController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Certificado certificado)
        {
            clsCertificado _certificado = new clsCertificado();
            _certificado.certificado = certificado;
            return _certificado.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Certificado certificado)
        {
            clsCertificado _certificado = new clsCertificado();
            _certificado.certificado = certificado;
            return _certificado.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Certificado certificado)
        {
            clsCertificado _certificado = new clsCertificado();
            _certificado.certificado = certificado;
            return _certificado.Eliminar();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Certificado ConsultarXId(int id)
        {
            clsCertificado _certificado = new clsCertificado();
            return _certificado.Consultar(id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsCertificado _certificado = new clsCertificado();
            return _certificado.llenarTabla();
        }
    }
}
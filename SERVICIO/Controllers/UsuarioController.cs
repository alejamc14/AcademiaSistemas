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
    [RoutePrefix("api/Usuario")]
    [Authorize]
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Usuario usuario, int IdPerfil)
        {
            clsUsuario _usuario = new clsUsuario();
            _usuario.usuario = usuario;
            return _usuario.Insertar(IdPerfil);
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Usuario usuario, int IdPerfil, int IdUsuarioPerfil)
        {
            clsUsuario _usuario = new clsUsuario();
            _usuario.usuario = usuario;
            return _usuario.Actualizar(usuario.Id,IdPerfil,IdUsuarioPerfil);
        }
        [HttpPut]
        [Route("Activar")]
        public string Activar( int IdUsuarioPerfil, bool Activo)
        {
            clsUsuario _usuario = new clsUsuario();
            return _usuario.Activar( IdUsuarioPerfil, Activo);
        }
        [HttpGet]
        [Route("ListarUsuarios")]
        public IQueryable ListarUsuarios()
        {
            clsUsuario _usuario = new clsUsuario();
            return _usuario.ListarUsuarios();
        }
    }
}
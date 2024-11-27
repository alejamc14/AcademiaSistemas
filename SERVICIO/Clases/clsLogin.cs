using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVICIO.Clases
{
    public class clsLogin
    {
        public clsLogin() 
        {
            loginRespuesta = new LoginRespuesta();
        }
        private AcademiaSistemasEntities academiaSistemasEntities1 = new AcademiaSistemasEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        private bool ValidarUsuario()
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                Usuario usuario = academiaSistemasEntities1.Usuarios.FirstOrDefault(u => u.NombreUsuario == login.Usuario);
                if (usuario == null)
                {
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }
                byte[] arrBytesSalt = Convert.FromBase64String(usuario.Salt);
                string ClaveCifrada = cifrar.HashPassword(login.Clave, arrBytesSalt);
                login.Clave = ClaveCifrada;
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario())
            {
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from U in academiaSistemasEntities1.Set<Usuario>()
                       join UP in academiaSistemasEntities1.Set<Usuario_Perfil>()
                       on U.Id equals UP.IdUsuario
                       join P in academiaSistemasEntities1.Set<Perfil>()
                       on UP.IdPerfil equals P.Id
                       where U.NombreUsuario == login.Usuario &&
                             U.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = U.NombreUsuario,
                           Perfil = P.Nombre,
                           Token = token,
                           Autenticado = true,
                           PaginaInicio = P.PaginaNavegar,
                           Mensaje = "Usuario autenticado",
                       };
            }
            else
            {
                return null;
            }
        }
    }
}
using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVICIO.Clases
{
    public class clsUsuario
    {
        AcademiaSistemasEntities academiaSistemasEntities1 = new AcademiaSistemasEntities();

        public Usuario usuario { get; set; }
        public string Insertar(int IdPerfil)
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                cifrar.Password = usuario.Clave;
                if (cifrar.CifrarClave())
                {
                    usuario.Clave = cifrar.PasswordCifrado;
                    usuario.Salt = cifrar.Salt;
                    academiaSistemasEntities1.Usuarios.Add(usuario);
                    academiaSistemasEntities1.SaveChanges();
                    

                    Usuario_Perfil UsuarioPerfil = new Usuario_Perfil();
                    UsuarioPerfil.IdPerfil = IdPerfil;
                    UsuarioPerfil.IdUsuario = usuario.Id;
                    UsuarioPerfil.Activo = true;
                    academiaSistemasEntities1.Usuario_Perfil.Add(UsuarioPerfil);
                    academiaSistemasEntities1.SaveChanges();
                    
                    return $"Se creo el usuario: {usuario.NombreUsuario}";


                }
                else
                {
                    return "No pudo generar la clave cifrada, no creó el usuario";
                }
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }
        }
        public string Actualizar(int IdUsuario, int IdPerfil, int IdUsuarioPerfil)
        {
            try
            {
                Usuario _usuario = academiaSistemasEntities1.Usuarios.FirstOrDefault(u => u.Id == IdUsuario);
                _usuario.NombreUsuario = usuario.NombreUsuario;
                academiaSistemasEntities1.SaveChanges();

                Usuario_Perfil usuario_Perfil = academiaSistemasEntities1.Usuario_Perfil.FirstOrDefault(u => u.Id == IdUsuarioPerfil);
                usuario_Perfil.IdPerfil = IdPerfil;
                academiaSistemasEntities1.SaveChanges();

                return $"Se actualizaron los datos del usuario: {usuario.NombreUsuario}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Activar(int IdUsuarioPerfil,bool Activo)
        {
            try
            {
                Usuario_Perfil usuario_Perfil = academiaSistemasEntities1.Usuario_Perfil.FirstOrDefault(u => u.Id == IdUsuarioPerfil);
                if (usuario_Perfil == null)
                {
                    return "El usuario no existe en la base de datos";
                }
                usuario_Perfil.Activo = Activo;
                academiaSistemasEntities1.SaveChanges();
                return "Se activó el usuario";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public IQueryable ListarUsuarios()
        {
            return from P in academiaSistemasEntities1.Set<Perfil>()
                   join UP in academiaSistemasEntities1.Set<Usuario_Perfil>()
                   on P.Id equals UP.IdPerfil
                   join U in academiaSistemasEntities1.Set<Usuario>()
                   on UP.IdUsuario equals U.Id
                   join E in academiaSistemasEntities1.Set<Estudiante>()
                   on U.IdEstudiante equals E.Id into Estudiantes
                   from Est in Estudiantes.DefaultIfEmpty()
                   join PF in academiaSistemasEntities1.Set<Profesor>()
                   on U.IdProfesor equals PF.Id into Profesores
                   from Prof in Profesores.DefaultIfEmpty()
                   orderby U.NombreUsuario
                   select new
                   {
                       Editar = "<button type=\"button\" id=\"btnEditar\" class=\"btn btn-success\" onclick=\"EditarUsuario('"+ U.Id +"', '" + (Est != null ? Est.Documento : Prof.Documento) + "' , '" + (Est != null ? Est.Nombre : Prof.Nombre) + "', '" + U.NombreUsuario + "', '" + P.Id + "', '"+ UP.Id +"')\"><i class=\"bi bi-pencil-square\"></i></button>"
                       + "&nbsp;&nbsp;&nbsp;&nbsp<button type=\"button\" id=\"btnEditar\" class=\"btn btn-success\" onclick=\"Activar('"+ UP.Id +"', '"+ (UP.Activo ? "false" : "true") +"')\"><i class=\"bi bi-power\"></i></button>",
                       Documento = Est != null ? Est.Documento : Prof.Documento,
                       Nombre = Est != null ? Est.Nombre : Prof.Nombre,
                       Usuario = U.NombreUsuario,
                       Perfil = P.Nombre,
                       Activo = UP.Activo ? "SI" : "NO"
                   };
        }
    }
}
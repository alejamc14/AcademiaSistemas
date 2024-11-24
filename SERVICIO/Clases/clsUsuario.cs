using SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVICIO.Clases
{
    public class clsUsuario
    {
        AcademiaSistemasEntities1 academiaSistemasEntities1 = new AcademiaSistemasEntities1();

        public Usuario usuario { get; set; }
        public string Insertar()
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
    }
}
using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.LogicaDeNegocio.Usuarios
{
    public class Validador
    {
        public static void ValideElUsuario(UsuarioDTO usuario)
        {
            if (string.IsNullOrEmpty(usuario.Nombre))
            {
                throw new Exception("Nombre invalido");
            }

            if (string.IsNullOrEmpty(usuario.Correo))
            {
                throw new Exception("Correo invalido");
            }

            if (string.IsNullOrEmpty(usuario.Contraseña))
            {
                throw new Exception("Contraseña invalida");
            }
        }
    }
}

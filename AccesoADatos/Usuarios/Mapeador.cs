using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.AccesoADatos.Usuarios
{
    public static class Mapeador
    {
        public static Usuario MapeeDesdeDTO(UsuarioDTO usuarioDTO)
        {
            try
            {
                return new Usuario()
                {
                    Contraseña = usuarioDTO.Contraseña,
                    Correo = usuarioDTO.Correo,
                    FacebookId = usuarioDTO.FacebookId,
                    GoogleId = usuarioDTO.GoogleId,
                    Nombre = usuarioDTO.Nombre,
                    UsuarioId = usuarioDTO.UsuarioId,
                    FechaDeActualizacion = usuarioDTO.FechaDeActualizacion,
                    FechaDeCreacion = usuarioDTO.FechaDeCreacion
                };
            }
            catch (Exception)
            {
                throw new Exception("Error en mapeo");
            }
        }

        public static UsuarioDTO MapeeADTO(Usuario usuario)
        {
            try
            {
                return new UsuarioDTO()
                {
                    Correo = usuario.Correo,
                    Nombre = usuario.Nombre,
                    UsuarioId = usuario.UsuarioId,
                    FechaDeActualizacion = usuario.FechaDeActualizacion,
                    FechaDeCreacion = usuario.FechaDeCreacion
                };
            }
            catch (Exception)
            {
                throw new Exception("Error en mapeo");
            }
        }

        public static List<UsuarioDTO> MapeeADTO(List<Usuario> usuarios)
        {
            List<UsuarioDTO> usuariosDTO = new();

            foreach (var usuario in usuarios)
            {
                usuariosDTO.Add(MapeeADTO(usuario));
            }

            return usuariosDTO;
        }
    }
}

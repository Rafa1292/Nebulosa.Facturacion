using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.LogicaDeNegocio.Usuarios
{
    public interface IUsuarioAccesoADatos
    {
        Task ActualiceElNombreDeUsuario(UsuarioDTO usuarioDTO);
        Task ActualiceLaContraseña(UsuarioDTO usuarioDTO);
        Task AgregueElUsuario(UsuarioDTO usuarioDTO);
        Task<string> ObtengaElTokenDerecuperacionDeContraseña(string correo);
        Task<UsuarioDTO> ObtengaElUsuario(int id);
        Task<UsuarioDTO> ObtengaElUsuario(UsuarioLoginDTO usuarioLogin);
        Task<List<UsuarioDTO>> ObtengaLaListaDeUsuarios();
        Task RecupereLaContraseña(RecuperarContraseñaDTO recuperarContraseña);
    }
}

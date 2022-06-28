using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Aplicacion.Servicio
{
    public interface IUsuarioServicio
    {
        Task ActualiceElNombreDeUsuario(UsuarioDTO usuario);
        Task ActualiceLaContraseña(UsuarioDTO usuario);
        Task AgregueElUsuario(UsuarioDTO usuario);
        Task<string> ObtengaElTokenDerecuperacionDeContraseña(string correo);
        Task<UsuarioDTO> ObtengaElUsuario(int id);
        Task<UsuarioDTO> ObtengaElUsuario(UsuarioLoginDTO usuarioLogino);
        Task<List<UsuarioDTO>> ObtengaLaListaDeUsuarios();
        Task RecupereLaContraseña(RecuperarContraseñaDTO recuperarContraseña);
    }
}

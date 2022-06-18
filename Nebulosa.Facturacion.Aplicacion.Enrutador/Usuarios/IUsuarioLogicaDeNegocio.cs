using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Aplicacion.Enrutador.Usuarios
{
    public interface IUsuarioLogicaDeNegocio
    {
        Task ActualiceElNombreDeUsuario(UsuarioDTO usuario);
        Task ActualiceLaContraseña(UsuarioDTO usuario);
        Task AgregueElUsuario(UsuarioDTO usuario);
        Task<UsuarioDTO> ObtengaElUsuario(int id);
        Task<UsuarioDTO> ObtengaElUsuario(UsuarioLoginDTO usuarioLogin);
        Task<List<UsuarioDTO>> ObtengaLaListaDeUsuarios();
    }
}

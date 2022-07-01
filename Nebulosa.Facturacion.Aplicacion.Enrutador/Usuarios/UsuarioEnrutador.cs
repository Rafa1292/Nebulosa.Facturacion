using Nebulosa.Facturacion.Aplicacion.Servicio;
using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Aplicacion.Enrutador.Usuarios
{
    public class UsuarioEnrutador : IUsuarioServicio
    {
        private readonly IUsuarioLogicaDeNegocio _logicaDeNegocio;

        public UsuarioEnrutador(IUsuarioLogicaDeNegocio logicaDeNegocio)
        {
            _logicaDeNegocio = logicaDeNegocio;
        }

        public async Task AgregueElUsuario(UsuarioDTO usuario)
        {
            await _logicaDeNegocio.AgregueElUsuario(usuario);
        }

        public async Task ActualiceElNombreDeUsuario(UsuarioDTO usuario)
        {
            await _logicaDeNegocio.ActualiceElNombreDeUsuario(usuario);
        }

        public async Task ActualiceLaContraseña(UsuarioDTO usuario)
        {
            await _logicaDeNegocio.ActualiceLaContraseña(usuario);
        }

        public async Task<List<UsuarioDTO>> ObtengaLaListaDeUsuarios()
        {
            return await _logicaDeNegocio.ObtengaLaListaDeUsuarios();
        }

        public async Task<UsuarioDTO> ObtengaElUsuario(int id)
        {
            return await _logicaDeNegocio.ObtengaElUsuario(id);
        }

        public async Task<UsuarioDTO> ObtengaElUsuario(UsuarioLoginDTO usuarioLogin)
        {
            return await _logicaDeNegocio.ObtengaElUsuario(usuarioLogin);
        }

        public async Task<string> ObtengaElTokenDerecuperacionDeContraseña(string correo)
        {
            return await _logicaDeNegocio.ObtengaElTokenDerecuperacionDeContraseña(correo);
        }

        public async Task RecupereLaContraseña(RecuperarContraseñaDTO recuperarContraseña)
        {
            await _logicaDeNegocio.RecupereLaContraseña(recuperarContraseña);
        }
    }
}

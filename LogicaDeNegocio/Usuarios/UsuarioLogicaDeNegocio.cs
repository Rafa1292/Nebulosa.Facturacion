using Nebulosa.Facturacion.Aplicacion.Enrutador.Usuarios;
using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.LogicaDeNegocio.Usuarios
{
    public class UsuarioLogicaDeNegocio : IUsuarioLogicaDeNegocio
    {
        private readonly IUsuarioAccesoADatos _usuarioAcceso;

        public UsuarioLogicaDeNegocio(IUsuarioAccesoADatos usuarioAcceso)
        {
            _usuarioAcceso = usuarioAcceso;
        }

        public async Task AgregueElUsuario(UsuarioDTO usuario)
        {
            Validador.ValideElUsuario(usuario);
            usuario.FechaDeCreacion = DateTime.Now;
            await _usuarioAcceso.AgregueElUsuario(usuario);
        }

        public async Task ActualiceElNombreDeUsuario(UsuarioDTO usuario)
        {
            usuario.FechaDeActualizacion = DateTime.Now;
            await _usuarioAcceso.ActualiceElNombreDeUsuario(usuario);
        }

        public async Task ActualiceLaContraseña(UsuarioDTO usuario)
        {
            usuario.FechaDeActualizacion = DateTime.Now;
            await _usuarioAcceso.ActualiceLaContraseña(usuario);
        }

        public async Task<List<UsuarioDTO>> ObtengaLaListaDeUsuarios()
        {
            return await _usuarioAcceso.ObtengaLaListaDeUsuarios();
        }

        public async Task<UsuarioDTO> ObtengaElUsuario(int id)
        {
            return await _usuarioAcceso.ObtengaElUsuario(id);
        }

        public async Task<UsuarioDTO> ObtengaElUsuario(UsuarioLoginDTO usuarioLogin)
        {
            return await _usuarioAcceso.ObtengaElUsuario(usuarioLogin);
        }


    }
}

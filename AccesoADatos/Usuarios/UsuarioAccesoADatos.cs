
using Nebulosa.Facturacion.Compartida.DTO;
using Nebulosa.Facturacion.LogicaDeNegocio.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.AccesoADatos.Usuarios
{
    public class UsuarioAccesoADatos : IUsuarioAccesoADatos
    {
        private readonly IUsuarioRepositorio _repositorio;

        public UsuarioAccesoADatos(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task AgregueElUsuario(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = Mapeador.MapeeDesdeDTO(usuarioDTO);
            await _repositorio.AgregueElUsuario(usuario);    
        }

        public async Task ActualiceElNombreDeUsuario(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = Mapeador.MapeeDesdeDTO(usuarioDTO);
            await _repositorio.ActualiceElNombreDeUsuario(usuario);
        }

        public async Task<List<UsuarioDTO>> ObtengaLaListaDeUsuarios()
        {
            List<Usuario> usuarios = await _repositorio.ObtengaLaListaDeUsuarios();
            return Mapeador.MapeeADTO(usuarios);
        }

        public async Task<UsuarioDTO> ObtengaElUsuario(int id)
        {
            Usuario usuario = await _repositorio.ObtengaElUsuario(id);

            return Mapeador.MapeeADTO(usuario);
        }

        public async Task<UsuarioDTO> ObtengaElUsuario(UsuarioLoginDTO usuarioLogin)
        {
            Usuario usuario = await _repositorio.ObtengaElUsuario(usuarioLogin);

            if (usuario == null)
            {
                throw new Exception("Usuario o contraseña incorrecto");
            }

            return Mapeador.MapeeADTO(usuario);
        }

        public async Task ActualiceLaContraseña(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = Mapeador.MapeeDesdeDTO(usuarioDTO);

            await _repositorio.ActualiceLaContraseña(usuario, usuarioDTO.ContraseñaAnterior);
        }

        public async Task<string> ObtengaElTokenDerecuperacionDeContraseña(string correo)
        {
            return await _repositorio.ObtengaElTokenDerecuperacionDeContraseña(correo);
        }

        public async Task RecupereLaContraseña(RecuperarContraseñaDTO recuperarContraseña)
        {
            await _repositorio.RecupereLaContraseña(recuperarContraseña);
        }

    }
}

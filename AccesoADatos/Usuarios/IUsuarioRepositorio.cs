using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.AccesoADatos.Usuarios
{
    public interface IUsuarioRepositorio
    {
        Task ActualiceElNombreDeUsuario(Usuario usuario);
        Task ActualiceLaContraseña(Usuario usuario, string contraseñaAnterior);
        Task AgregueElUsuario(Usuario usuario);
        Task<string> ObtengaElTokenDerecuperacionDeContraseña(string correo);
        Task<Usuario> ObtengaElUsuario(int id);
        Task<Usuario> ObtengaElUsuario(UsuarioLoginDTO usuarioLogin);
        Task<List<Usuario>> ObtengaLaListaDeUsuarios();
        Task RecupereLaContraseña(RecuperarContraseñaDTO recuperarContraseña);
    }
}

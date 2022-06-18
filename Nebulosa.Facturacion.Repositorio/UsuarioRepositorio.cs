using Microsoft.EntityFrameworkCore;
using Nebulosa.Facturacion.AccesoADatos.Usuarios;
using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _contexto;

        public UsuarioRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task AgregueElUsuario(Usuario usuario)
        {
            await _contexto.Usuarios.AddAsync(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task ActualiceElNombreDeUsuario(Usuario usuario)
        {
            Usuario usuarioActual = await ObtengaElUsuario(usuario.UsuarioId);
            usuarioActual.Nombre = usuario.Nombre;
            _contexto.Usuarios.Attach(usuarioActual).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

        public async Task ActualiceLaContraseña(Usuario usuario, string contraseñaAnterior)
        {
            Usuario usuarioActual = await ObtengaElUsuario(usuario.UsuarioId);

            if (!usuarioActual.Contraseña.Equals(contraseñaAnterior))
            {
                throw new Exception("La contraseña no coincide");
            }

            usuarioActual.Contraseña = usuario.Contraseña;
            _contexto.Usuarios.Attach(usuarioActual).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

        public async Task<List<Usuario>> ObtengaLaListaDeUsuarios()
        {
            return await _contexto.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObtengaElUsuario(int id)
        {
            return await _contexto.Usuarios.FirstAsync(x => x.UsuarioId == id);
        }

        public async Task<Usuario> ObtengaElUsuario(UsuarioLoginDTO usuarioLogin)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(x => x.Correo.Equals(usuarioLogin.Correo) && x.Contraseña.Equals(usuarioLogin.Contraseña));
        }

    }
}

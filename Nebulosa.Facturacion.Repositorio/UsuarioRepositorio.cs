using Microsoft.EntityFrameworkCore;
using Nebulosa.Facturacion.AccesoADatos.Usuarios;
using Nebulosa.Facturacion.Compartida.DTO;
using Nebulosa.Facturacion.Compartida.Helper;
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
            usuario.Contraseña = EncryptHelper.GetSHA256(usuario.Contraseña);
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

            usuarioActual.Contraseña = EncryptHelper.GetSHA256(usuario.Contraseña);
            _contexto.Usuarios.Attach(usuarioActual).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

        public async Task<List<Usuario>> ObtengaLaListaDeUsuarios()
        {
            return await _contexto.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObtengaElUsuario(int id)
        {
            return await _contexto.Usuarios.AsNoTracking().FirstAsync(x => x.UsuarioId == id);
        }

        public async Task<Usuario> ObtengaElUsuario(string correo)
        {
            return await _contexto.Usuarios.AsNoTracking().FirstAsync(x => x.Correo.ToLower() == correo.ToLower());
        }

        public async Task<Usuario> ObtengaElUsuario(UsuarioLoginDTO usuarioLogin)
        {
            usuarioLogin.Contraseña = EncryptHelper.GetSHA256(usuarioLogin.Contraseña);
            return await _contexto.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => 
                            x.Correo.Equals(usuarioLogin.Correo) && x.Contraseña.Equals(usuarioLogin.Contraseña));
        }

        public async Task<string> ObtengaElTokenDerecuperacionDeContraseña(string correo)
        {
            var usuario = await ObtengaElUsuario(correo);

            if (usuario == null)
                throw new Exception("Correo incorrecto");

            return EncryptHelper.GetSHA256(usuario.Contraseña);

        }

        public async Task RecupereLaContraseña(RecuperarContraseñaDTO recuperarContraseña)
        {
            Usuario usuario = await ObtengaElUsuario(recuperarContraseña.Correo);
            string token = await ObtengaElTokenDerecuperacionDeContraseña(recuperarContraseña.Correo);
            
            if (!token.Equals(recuperarContraseña.Token))
                throw new Exception("El token es invalido");

            string contraseñaAnterior = usuario.Contraseña;
            usuario.Contraseña = recuperarContraseña.NuevaContraseña;
            await ActualiceLaContraseña(usuario, contraseñaAnterior);
        }
    }
}

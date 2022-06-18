using Nebulosa.Facturacion.Aplicacion.Servicio;
using Nebulosa.Facturacion.Compartida.DTO;
using System.Transactions;

namespace Nebulosa.Facturacion.Servidor.Api
{
    public class UsuarioAPI
    {
        private readonly string _urlBase = "Usuario";

        public UsuarioAPI(WebApplication app)
        {
            app.MapPost($"{_urlBase}/Agregue",
            (UsuarioDTO usuario, IUsuarioServicio servicio) =>
            AgregueElUsuario(usuario, servicio));

            app.MapGet($"{_urlBase}/",
            (int id, IUsuarioServicio servicio) =>
            ObtengaElUsuario(id, servicio));

            app.MapPut($"{_urlBase}/ActualiceElNombre",
            (UsuarioDTO usuario, IUsuarioServicio servicio) =>
            ActualiceElNombreDeUsuario(usuario, servicio));

            app.MapPut($"{_urlBase}/ActualiceLaContraseña",
            (UsuarioDTO usuario, IUsuarioServicio servicio) =>
            ActualiceLaContraseña(usuario, servicio));

            app.MapGet($"{_urlBase}/Liste",
            (IUsuarioServicio servicio) =>
            ObtengaLaListaDeUsuarios(servicio));
        }

        async Task<IResult> AgregueElUsuario(UsuarioDTO usuario, IUsuarioServicio servicio)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await servicio.AgregueElUsuario(usuario);
                    scope.Complete();
                    return Results.Ok("Usuario agregado correctamente");
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    return Results.Conflict(e.Message);
                }
            }
        }

        async Task<IResult> ObtengaLaListaDeUsuarios(IUsuarioServicio servicio)
        {
            try
            {
                List<UsuarioDTO> usuarios = await servicio.ObtengaLaListaDeUsuarios();
                return Results.Ok(usuarios);
            }
            catch (Exception e)
            {
                return Results.Conflict(e.Message);
            }
        }

        async Task<IResult> ActualiceElNombreDeUsuario(UsuarioDTO usuario, IUsuarioServicio servicio)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await servicio.ActualiceElNombreDeUsuario(usuario);
                    scope.Complete();
                    return Results.Ok("Usuario actualizado correctamente");
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    return Results.Conflict(e.Message);
                }
            }
        }

        async Task<IResult> ActualiceLaContraseña(UsuarioDTO usuario, IUsuarioServicio servicio)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await servicio.ActualiceLaContraseña(usuario);
                    scope.Complete();
                    return Results.Ok("Usuario actualizado correctamente");
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    return Results.Conflict(e.Message);
                }
            }
        }

        async Task<IResult> ObtengaElUsuario(int id, IUsuarioServicio servicio)
        {
            try
            {
                UsuarioDTO usuario = await servicio.ObtengaElUsuario(id);
                return Results.Ok(usuario);
            }
            catch (Exception e)
            {
                return Results.Conflict(e.Message);
            }
        }

    }
}

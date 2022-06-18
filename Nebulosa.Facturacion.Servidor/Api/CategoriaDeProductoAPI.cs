using Nebulosa.Facturacion.Aplicacion.Servicio;
using Nebulosa.Facturacion.Compartida.DTO;
using System.Transactions;

namespace Nebulosa.Facturacion.Servidor.Api
{
    public class CategoriaDeProductoAPI
    {
        private readonly string _urlBase = "CategoriaDeProducto";
        public CategoriaDeProductoAPI(WebApplication app)
        {
            app.MapGet($"{_urlBase}/",
            (int id, ICategoriaDeProductoServicio servicio) =>
            ObtengaLaCategoria(id, servicio));

            app.MapPost($"{_urlBase}/Agregue",
            (CategoriaDeProductoDTO categoriaDeProducto, ICategoriaDeProductoServicio servicio) =>
            AgregueLaCategoria(categoriaDeProducto, servicio));

            app.MapPut($"{_urlBase}/Actualice",
            (CategoriaDeProductoDTO categoriaDeProducto, ICategoriaDeProductoServicio servicio) =>
            ActualiceLaCategoria(categoriaDeProducto, servicio));

            app.MapDelete($"{_urlBase}/Elimine",
            (int id, ICategoriaDeProductoServicio servicio) =>
            ElimineLaCategoria(id, servicio));

            app.MapGet($"{_urlBase}/Liste",
            (ICategoriaDeProductoServicio servicio) =>
            ObtengaLaListaDeCategorias(servicio));
        }

        async Task<IResult> AgregueLaCategoria(CategoriaDeProductoDTO categoriaDeProducto, ICategoriaDeProductoServicio servicio)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await servicio.AgregueLaCategoria(categoriaDeProducto);
                    scope.Complete();
                    return Results.Ok("Categoria agregada correctamente");
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    return Results.Conflict(e.Message);
                }
            }
        }

        async Task<IResult> ActualiceLaCategoria(CategoriaDeProductoDTO categoriaDeProducto, ICategoriaDeProductoServicio servicio)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await servicio.ActualiceLaCategoria(categoriaDeProducto);
                    scope.Complete();
                    return Results.Ok("Categoria actualizada correctamente");
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    return Results.Conflict(e.Message);
                }
            }
        }

        async Task<IResult> ObtengaLaCategoria(int categoriaDeProductoId, ICategoriaDeProductoServicio servicio)
        {
            try
            {
                var respuesta = await servicio.ObtengaLaCategoria(categoriaDeProductoId);
                return Results.Ok(respuesta);
            }
            catch (Exception e)
            {
                return Results.Conflict(e.Message);
            }
        }

        async Task<IResult> ObtengaLaListaDeCategorias(ICategoriaDeProductoServicio servicio)
        {
            try
            {
                var respuesta = await servicio.ObtengaLaListaDeCategorias();
                return Results.Ok(respuesta);
            }
            catch (Exception e)
            {
                return Results.Conflict(e.Message);
            }
        }

        async Task<IResult> ElimineLaCategoria(int categoriaDeProductoId, ICategoriaDeProductoServicio servicio)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await servicio.ElimineLaCategoria(categoriaDeProductoId);
                    scope.Complete();
                    return Results.Ok("Categoria eliminada");
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    return Results.Conflict(e.Message);
                }
            }
        }

    }
}

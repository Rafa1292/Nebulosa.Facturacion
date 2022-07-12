using Microsoft.Data.SqlClient;
using Nebulosa.Facturacion.Aplicacion.Servicio;
using Nebulosa.Facturacion.Compartida.DTO;
using Nebulosa.Facturacion.Servidor.Helpers;
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

        async Task<RespuestaAPI<bool>> AgregueLaCategoria(CategoriaDeProductoDTO categoriaDeProducto, ICategoriaDeProductoServicio servicio)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if(await VerifiqueLaCategoria(categoriaDeProducto.Nombre, servicio))
                    {
                        scope.Complete();
                        return new RespuestaAPI<bool>(false, "Categoria agregada correctamente");
                    }

                    await servicio.AgregueLaCategoria(categoriaDeProducto);
                    scope.Complete();
                    return new RespuestaAPI<bool>(false, "Categoria agregada correctamente");
                }
                catch (ServerException e)
                {
                    scope.Dispose();
                    return new RespuestaAPI<bool>(true, e.Message);
                }
                catch (Exception e)
                {
                    return ProcesadorDeExcepcionesHelper<bool>.ProceseLaExcepcion(e);
                }
            }
        }

        async Task<bool> VerifiqueLaCategoria(string nombre, ICategoriaDeProductoServicio servicio)
        {
            try
            {
                return await servicio.VerifiqueLaCategoria(nombre);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        async Task<RespuestaAPI<bool>> ActualiceLaCategoria(CategoriaDeProductoDTO categoriaDeProducto, ICategoriaDeProductoServicio servicio)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await servicio.ActualiceLaCategoria(categoriaDeProducto);
                    scope.Complete();
                    return new RespuestaAPI<bool>(false, "Categoria actualizada correctamente");
                }
                catch (ServerException e)
                {
                    scope.Dispose();
                    return new RespuestaAPI<bool>(true, e.Message);
                }
                catch (Exception e)
                {
                    return ProcesadorDeExcepcionesHelper<bool>.ProceseLaExcepcion(e);
                }
            }
        }

        async Task<RespuestaAPI<CategoriaDeProductoDTO>> ObtengaLaCategoria(int categoriaDeProductoId, ICategoriaDeProductoServicio servicio)
        {
            try
            {
                var respuesta = await servicio.ObtengaLaCategoria(categoriaDeProductoId);
                return new RespuestaAPI<CategoriaDeProductoDTO>(false, "Solicitud exitosa", respuesta);
            }
            catch (ServerException e)
            {
                return new RespuestaAPI<CategoriaDeProductoDTO>(true, e.Message);
            }
            catch (Exception e)
            {
                return ProcesadorDeExcepcionesHelper<CategoriaDeProductoDTO>.ProceseLaExcepcion(e);
            }
        }

        async Task<RespuestaAPI<List<CategoriaDeProductoDTO>>> ObtengaLaListaDeCategorias(ICategoriaDeProductoServicio servicio)
        {
            try
            {
                var respuesta = await servicio.ObtengaLaListaDeCategorias();
                return new RespuestaAPI<List<CategoriaDeProductoDTO>>(false, "solicitud exitosa", respuesta);
            }
            catch (ServerException e)
            {
                return new RespuestaAPI<List<CategoriaDeProductoDTO>>(true, e.Message);
            }
            catch (Exception e)
            {
                return ProcesadorDeExcepcionesHelper<List<CategoriaDeProductoDTO>>.ProceseLaExcepcion(e);
            }
        }

        async Task<RespuestaAPI<bool>> ElimineLaCategoria(int categoriaDeProductoId, ICategoriaDeProductoServicio servicio)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await servicio.ElimineLaCategoria(categoriaDeProductoId);
                    scope.Complete();
                    return new RespuestaAPI<bool>(false, "Categoria eliminada");
                }
                catch (ServerException e)
                {
                    scope.Dispose();
                    return new RespuestaAPI<bool>(true, e.Message);
                }
                catch (Exception e)
                {
                    return ProcesadorDeExcepcionesHelper<bool>.ProceseLaExcepcion(e);
                }
            }
        }

    }
}

using Nebulosa.Facturacion.Aplicacion.Servicio;
using Nebulosa.Facturacion.Compartida.DTO;

namespace Nebulosa.Facturacion.Aplicacion.Enrutador.CategoriasDeProducto
{
    public class CategoriaDeProductoEnrutador : ICategoriaDeProductoServicio
    {
        private readonly ICategoriaDeProductoLogicaDeNegocio _logica;

        public CategoriaDeProductoEnrutador(ICategoriaDeProductoLogicaDeNegocio logica)
        {
            _logica = logica;
        }

        public async Task ActualiceLaCategoria(CategoriaDeProductoDTO categoriaDeProductoDTO)
        {
            await _logica.ActualiceLaCategoria(categoriaDeProductoDTO);
        }

        public async Task AgregueLaCategoria(CategoriaDeProductoDTO categoriaDeProducto)
        {
            await _logica.AgregueLaCategoria(categoriaDeProducto);
        }

        public async Task ElimineLaCategoria(int categoriaDeProductoId)
        {
            await _logica.ElimineLaCategoria(categoriaDeProductoId);
        }

        public async Task<CategoriaDeProductoDTO> ObtengaLaCategoria(int categoriaDeProductoId)
        {
            return await _logica.ObtengaLaCategoria(categoriaDeProductoId);
        }

        public async Task<bool> VerifiqueLaCategoria(string nombre)
        {
            return await _logica.VerifiqueLaCategoria(nombre);
        }

        public async Task<List<CategoriaDeProductoDTO>> ObtengaLaListaDeCategorias()
        {
            return await _logica.ObtengaLaListaDeCategorias();
        }
    }
}

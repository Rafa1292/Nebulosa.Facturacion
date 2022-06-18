using Nebulosa.Facturacion.LogicaDeNegocio.CategoriasDeProducto;
using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.AccesoADatos.CategoriasDeProducto
{
    public class CategoriaDeProductoAccesoADatos : ICategoriaDeProductoAccesoADatos
    {
        private readonly ICategoriaDeProductoRepositorio _repositorio;

        public CategoriaDeProductoAccesoADatos(ICategoriaDeProductoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task AgregueLaCategoria(CategoriaDeProductoDTO categoriaDeProductoDTO)
        {
            CategoriaDeProducto categoriaDeProducto = Mapeador.MapeeDesdeDTO(categoriaDeProductoDTO);
            await _repositorio.AgregueLaCategoria(categoriaDeProducto);
        }

        public async Task ActualiceLaCategoria(CategoriaDeProductoDTO categoriaDeProductoDTO)
        {
            CategoriaDeProducto categoriaDeProducto = Mapeador.MapeeDesdeDTO(categoriaDeProductoDTO);
            await _repositorio.ActualiceLaCategoria(categoriaDeProducto);
        }

        public async Task ElimineLaCategoria(int categoriaDeProductoId)
        {
            await _repositorio.ElimineLaCategoria(categoriaDeProductoId);
        }

        public async Task<CategoriaDeProductoDTO> ObtengaLaCategoria(int categoriaDeProductoId)
        {
            CategoriaDeProducto categoriaDeProducto = await _repositorio.ObtengaLaCategoria(categoriaDeProductoId);

            return Mapeador.MapeeADTO(categoriaDeProducto);
        }

        public async Task<List<CategoriaDeProductoDTO>> ObtengaLaListaDeCategorias()
        {
            List<CategoriaDeProducto> categoriasDeProducto = await _repositorio.ObtengaLaListaDeCategorias();

            return Mapeador.MapeeADTO(categoriasDeProducto);
        }
    }
}

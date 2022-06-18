using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.LogicaDeNegocio.CategoriasDeProducto
{
    public interface ICategoriaDeProductoAccesoADatos
    {
        Task ActualiceLaCategoria(CategoriaDeProductoDTO categoriaDeProductoDTO);
        Task AgregueLaCategoria(CategoriaDeProductoDTO categoriaDeProducto);
        Task ElimineLaCategoria(int categoriaDeProductoId);
        Task<CategoriaDeProductoDTO> ObtengaLaCategoria(int categoriaDeProductoId);
        Task<List<CategoriaDeProductoDTO>> ObtengaLaListaDeCategorias();
    }
}

using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Aplicacion.Enrutador.CategoriasDeProducto
{
    public interface ICategoriaDeProductoLogicaDeNegocio
    {
        Task ActualiceLaCategoria(CategoriaDeProductoDTO categoriaDeProducto);
        Task AgregueLaCategoria(CategoriaDeProductoDTO categoriaDeProducto);
        Task ElimineLaCategoria(int categoriaDeProductoId);
        Task<CategoriaDeProductoDTO> ObtengaLaCategoria(int categoriaDeProductoId);
        Task<List<CategoriaDeProductoDTO>> ObtengaLaListaDeCategorias();
    }
}

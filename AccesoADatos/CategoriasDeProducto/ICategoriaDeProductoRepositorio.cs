using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.AccesoADatos.CategoriasDeProducto
{
    public interface ICategoriaDeProductoRepositorio
    {
        Task ActualiceLaCategoria(CategoriaDeProducto categoriaDeProducto);
        Task AgregueLaCategoria(CategoriaDeProducto categoriaDeProducto);
        Task ElimineLaCategoria(int categoriaDeProductoId);
        Task<CategoriaDeProducto> ObtengaLaCategoria(int categoriaDeProductoId);
        Task<bool> VerifiqueLaCategoria(string nombre);
        Task<List<CategoriaDeProducto>> ObtengaLaListaDeCategorias();
    }
}

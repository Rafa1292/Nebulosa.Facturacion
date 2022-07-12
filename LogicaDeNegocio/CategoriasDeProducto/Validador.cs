using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.LogicaDeNegocio.CategoriasDeProducto
{
    public class Validador
    {
        public static void ValideLaCategoria(CategoriaDeProductoDTO categoriaDeProducto)
        {
            if (string.IsNullOrEmpty(categoriaDeProducto.Nombre))
            {                
                throw new ServerException("Nombre invalido");
            }
        }
    }
}

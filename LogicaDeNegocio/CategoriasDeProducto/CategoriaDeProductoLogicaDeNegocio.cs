using Nebulosa.Facturacion.Aplicacion.Enrutador.CategoriasDeProducto;
using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.LogicaDeNegocio.CategoriasDeProducto
{
    public class CategoriaDeProductoLogicaDeNegocio : ICategoriaDeProductoLogicaDeNegocio
    {
        private readonly ICategoriaDeProductoAccesoADatos _accesoADatos;

        public CategoriaDeProductoLogicaDeNegocio(ICategoriaDeProductoAccesoADatos accesoADatos)
        {
            _accesoADatos = accesoADatos;
        }

        public async Task AgregueLaCategoria(CategoriaDeProductoDTO categoriaDeProducto)
        {
            Validador.ValideLaCategoria(categoriaDeProducto);
            categoriaDeProducto.FechaDeCreacion = DateTime.Now;
            await _accesoADatos.AgregueLaCategoria(categoriaDeProducto);
        }

        public async Task ActualiceLaCategoria(CategoriaDeProductoDTO categoriaDeProducto)
        {
            Validador.ValideLaCategoria(categoriaDeProducto);
            categoriaDeProducto.FechaDeActualizacion = DateTime.Now;
            await _accesoADatos.ActualiceLaCategoria(categoriaDeProducto);
        }

        public async Task ElimineLaCategoria(int categoriaDeProductoId)
        {
            await _accesoADatos.ElimineLaCategoria(categoriaDeProductoId);
        }

        public async Task<CategoriaDeProductoDTO> ObtengaLaCategoria(int categoriaDeProductoId)
        {
            return await _accesoADatos.ObtengaLaCategoria(categoriaDeProductoId);
        }

        public async Task<bool> VerifiqueLaCategoria(string nombre)
        {
            return await _accesoADatos.VerifiqueLaCategoria(nombre);
        }


        public async Task<List<CategoriaDeProductoDTO>> ObtengaLaListaDeCategorias()
        {
            return await _accesoADatos.ObtengaLaListaDeCategorias();
        }
    }
}

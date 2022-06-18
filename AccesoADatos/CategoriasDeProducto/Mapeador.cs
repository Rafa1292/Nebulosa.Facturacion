using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.AccesoADatos.CategoriasDeProducto
{
    public class Mapeador
    {
        public static CategoriaDeProducto MapeeDesdeDTO(CategoriaDeProductoDTO categoriaDeProductoDTO)
        {
            try
            {
                return new CategoriaDeProducto()
                {
                    CategoriaDeProductoId = categoriaDeProductoDTO.CategoriaDeProductoId,
                    Nombre = categoriaDeProductoDTO.Nombre,
                    FechaDeActualizacion = categoriaDeProductoDTO.FechaDeActualizacion,
                    FechaDeCreacion = categoriaDeProductoDTO.FechaDeCreacion,
                    UsuarioQueActualiza = categoriaDeProductoDTO.UsuarioQueActualiza,
                    UsuarioQueCrea = categoriaDeProductoDTO.UsuarioQueCrea
                };
            }
            catch (Exception)
            {
                throw new Exception("Error en mapeo");
            }
        }

        public static CategoriaDeProductoDTO MapeeADTO(CategoriaDeProducto categoriaDeProducto)
        {
            try
            {
                return new CategoriaDeProductoDTO()
                {
                    CategoriaDeProductoId = categoriaDeProducto.CategoriaDeProductoId,
                    Nombre = categoriaDeProducto.Nombre,
                    FechaDeActualizacion = categoriaDeProducto.FechaDeActualizacion,
                    FechaDeCreacion = categoriaDeProducto.FechaDeCreacion,
                    UsuarioQueActualiza = categoriaDeProducto.UsuarioQueActualiza,
                    UsuarioQueCrea = categoriaDeProducto.UsuarioQueCrea
                };
            }
            catch (Exception)
            {
                throw new Exception("Error en mapeo");
            }
        }

        public static List<CategoriaDeProductoDTO> MapeeADTO(List<CategoriaDeProducto> categoriasDeProducto)
        {
            try
            {
                List<CategoriaDeProductoDTO> categoriasDeProductoDTO = new List<CategoriaDeProductoDTO>();

                foreach (var categoriaDeProducto in categoriasDeProducto)
                {
                    categoriasDeProductoDTO.Add(MapeeADTO(categoriaDeProducto));
                }

                return categoriasDeProductoDTO;
            }
            catch (Exception)
            {
                throw new Exception("Error en mapeo");
            }
        }
    }
}

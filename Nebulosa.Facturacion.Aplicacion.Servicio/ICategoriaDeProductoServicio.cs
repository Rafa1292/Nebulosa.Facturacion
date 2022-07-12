﻿using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Aplicacion.Servicio
{
    public interface ICategoriaDeProductoServicio
    {
        Task ActualiceLaCategoria(CategoriaDeProductoDTO categoriaDeProductoDTO);
        Task AgregueLaCategoria(CategoriaDeProductoDTO categoriaDeProducto);
        Task ElimineLaCategoria(int categoriaDeProductoId);
        Task<CategoriaDeProductoDTO> ObtengaLaCategoria(int categoriaDeProductoId);
        Task<bool> VerifiqueLaCategoria(string nombre);
        Task<List<CategoriaDeProductoDTO>> ObtengaLaListaDeCategorias();
    }
}

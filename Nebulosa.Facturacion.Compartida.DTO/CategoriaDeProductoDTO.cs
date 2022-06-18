using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Compartida.DTO
{
    public class CategoriaDeProductoDTO
    {
        public int CategoriaDeProductoId { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public DateTime FechaDeActualizacion { get; set; }
        public int UsuarioQueCrea { get; set; }
        public int UsuarioQueActualiza { get; set; }
    }
}

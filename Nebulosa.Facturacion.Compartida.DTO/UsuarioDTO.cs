using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Compartida.DTO
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string? FacebookId { get; set; }
        public string? GoogleId { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string ContraseñaAnterior { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public DateTime FechaDeActualizacion { get; set; }

    }
}

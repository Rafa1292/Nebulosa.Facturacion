using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Compartida.DTO
{
    public class RecuperarContraseñaDTO
    {
        public string Token { get; set; }
        public string NuevaContraseña { get; set; }
        public string Correo { get; set; }
    }
}

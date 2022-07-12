using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Compartida.DTO
{
    public class RespuestaAPI<T>
    {
        public bool Error { get; set; }
        public string? Mensaje { get; set; }
        public T? Contenido { get; set; }

        public RespuestaAPI(bool error, string mensaje, T contenido)
        {
            Error = error;
            Mensaje = mensaje;
            Contenido = contenido;
        }

        public RespuestaAPI(bool error, string mensaje)
        {
            Error = error;
            Mensaje = mensaje;
        }

        public RespuestaAPI()
        {
        }

    }
}

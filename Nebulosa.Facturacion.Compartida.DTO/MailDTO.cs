using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Compartida.DTO
{
    public class MailDTO
    {
        public string Address { get; set; }
        public string Subject { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
    }
}

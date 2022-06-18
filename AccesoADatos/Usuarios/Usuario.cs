using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.AccesoADatos.Usuarios
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string? FacebookId { get; set; }
        public string? GoogleId { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public DateTime FechaDeActualizacion { get; set; }
    }
}

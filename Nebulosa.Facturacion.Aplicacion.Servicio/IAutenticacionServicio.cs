using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Aplicacion.Servicio
{
    public interface IAutenticacionServicio
    {
        Task<UsuarioDTO> ObtenerUsuario(UsuarioLoginDTO usuarioLogin);
    }
}

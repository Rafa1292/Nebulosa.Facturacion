using Nebulosa.Facturacion.Aplicacion.Servicio;
using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Aplicacion.Enrutador.Autenticacion
{
    public class AutenticacionEnrutador : IAutenticacionServicio
    {
        private readonly IUsuarioServicio _usuarioServicio;

        public AutenticacionEnrutador(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        public async Task<UsuarioDTO> ObtenerUsuario(UsuarioLoginDTO usuarioLogin)
        {
            return await _usuarioServicio.ObtengaElUsuario(usuarioLogin);
        }
    }
}

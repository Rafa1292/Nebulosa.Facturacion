using Microsoft.IdentityModel.Tokens;
using Nebulosa.Facturacion.Aplicacion.Servicio;
using Nebulosa.Facturacion.Compartida.DTO;
using Nebulosa.Facturacion.Compartida.Helper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Nebulosa.Facturacion.Servidor.Api.Seguridad
{
    public class AutenticacionAPI
    {
        private readonly WebApplication _app;

        public AutenticacionAPI(WebApplication app)
        {
            _app = app;
            app.MapPost("/Login",
                (UsuarioLoginDTO usuario, IAutenticacionServicio servicio) => Login(usuario, servicio))
                .Accepts<UsuarioLoginDTO>("application/json")
                .Produces<string>();

            app.MapPost("/EnviarCorreoDeRecuperacion",
                (MailDTO mail, IAutenticacionServicio servicio) => EnviarCorreoDeRecuperacion(mail, servicio));

            app.MapPost("/RecupereLaContraseña",
                (RecuperarContraseñaDTO recuperarContraseña, IAutenticacionServicio servicio) => RecupereLaContraseña(recuperarContraseña, servicio));
        }

        async Task<RespuestaAPI<string>> Login(UsuarioLoginDTO usuario, IAutenticacionServicio servicio)
        {
            try
            {
                var usuarioLogueado = await servicio.ObtenerUsuario(usuario);
                string tokenString = ObtengaElToken(usuarioLogueado);

                return new RespuestaAPI<string>(false, tokenString);

            }
            catch (Exception e)
            {
                return new RespuestaAPI<string>(true, e.Message);
            }
        }

        string ObtengaElToken(UsuarioDTO usuario)
        {
            try
            {

                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Correo),
                new Claim(ClaimTypes.Name, usuario.Nombre),
             };
                var token = new JwtSecurityToken(
                    issuer: _app.Configuration["Jwt:Issuer"],
                    audience: _app.Configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(60),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_app.Configuration["Jwt:Key"])),
                        SecurityAlgorithms.HmacSha256)
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        async Task<RespuestaAPI<bool>> EnviarCorreoDeRecuperacion(MailDTO mail, IAutenticacionServicio servicio)
        {
            try
            {
                string linkDeRecuperacion = await ObtenerLinkDeRecuperacion(mail.Address, servicio);
                mail.Body += linkDeRecuperacion;
                await MailHelper.SendMail(mail, _app.Configuration["Mail:Password"]);
                return new RespuestaAPI<bool>(false, "Correo  enviado exitosamente");
            }
            catch (Exception e)
            {

                return new RespuestaAPI<bool>(true, e.Message);
            }
        }

        async Task<string> ObtenerLinkDeRecuperacion(string mail, IAutenticacionServicio servicio)
        {
            try
            {
                string token = await servicio.ObtengaElTokenDerecuperacionDeContraseña(mail);
                string linkDeRecuperacion = $"http://localhost:8080/new-password/{token}";
                return linkDeRecuperacion;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        async Task<RespuestaAPI<bool>> RecupereLaContraseña(RecuperarContraseñaDTO recuperarContraseña, IAutenticacionServicio servicio)
        {
            try
            {
                await servicio.RecupereLaContraseña(recuperarContraseña);
                return new RespuestaAPI<bool>(false, "Operacion realizada con exito");
            }
            catch (Exception e)
            {

                return new RespuestaAPI<bool>(true, e.Message);
            }
        }

    }
}

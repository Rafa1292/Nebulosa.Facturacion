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
        }

        async Task<IResult> Login(UsuarioLoginDTO usuario, IAutenticacionServicio servicio)
        {
            try
            {
                var usuarioLogueado = await servicio.ObtenerUsuario(usuario);
                string tokenString = ObtengaElToken(usuarioLogueado);

                return Results.Ok(tokenString);

            }
            catch (Exception e)
            {
                return Results.Conflict(e.Message);
            }
        }

        string ObtengaElToken(UsuarioDTO usuario)
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

    }
}

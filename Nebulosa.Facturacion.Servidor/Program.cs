using Nebulosa.Facturacion.LogicaDeNegocio.CategoriasDeProducto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Nebulosa.Facturacion.Aplicacion.Enrutador.Autenticacion;
using Nebulosa.Facturacion.Aplicacion.Enrutador.CategoriasDeProducto;
using Nebulosa.Facturacion.Aplicacion.Servicio;
using Nebulosa.Facturacion.Compartida.DTO;
using Nebulosa.Facturacion.Compartida.Helper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Nebulosa.Facturacion.AccesoADatos.CategoriasDeProducto;
using Nebulosa.Facturacion.Repositorio;
using Microsoft.EntityFrameworkCore;
using Nebulosa.Facturacion.Servidor.Api;
using Nebulosa.Facturacion.Aplicacion.Enrutador.Usuarios;
using Nebulosa.Facturacion.LogicaDeNegocio.Usuarios;
using Nebulosa.Facturacion.AccesoADatos.Usuarios;
using Nebulosa.Facturacion.Servidor.Api.Seguridad;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Contexto>();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "JWT Bearer autenticacion",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
   {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id= "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
   });
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ICategoriaDeProductoServicio, CategoriaDeProductoEnrutador>();
builder.Services.AddScoped<ICategoriaDeProductoLogicaDeNegocio, CategoriaDeProductoLogicaDeNegocio>();
builder.Services.AddScoped<ICategoriaDeProductoAccesoADatos, CategoriaDeProductoAccesoADatos>();
builder.Services.AddScoped<ICategoriaDeProductoRepositorio, CategoriaDeProductoRepositorio>();

builder.Services.AddScoped<IUsuarioServicio, UsuarioEnrutador>();
builder.Services.AddScoped<IUsuarioLogicaDeNegocio, UsuarioLogicaDeNegocio>();
builder.Services.AddScoped<IUsuarioAccesoADatos, UsuarioAccesoADatos>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

builder.Services.AddScoped<IAutenticacionServicio, AutenticacionEnrutador>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseAuthorization();
app.UseAuthentication();

new CategoriaDeProductoAPI(app);
new UsuarioAPI(app);
new AutenticacionAPI(app);






app.UseSwaggerUI();

app.Run();

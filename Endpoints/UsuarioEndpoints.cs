using System.Text.Json;
using Comercial.Api.Contracts.Users;
using Comercial.Api.Database;
using Comercial.Api.Models;
using Comercial.Api.Repository;
using Comercial.Api.Services.Jwt;
using BC = BCrypt.Net.BCrypt;

namespace Comercial.Api.Endpoints;

public static class UsuarioEndpoints
{
    public static void MapUsuarioEndpoins(this IEndpointRouteBuilder app)
    {
        app.MapPut("usuarios", async (
            UpdateUserRequest request,
            IUsuarioRepository usuarioRepository,
            ApplicationDbContext dbContext) =>
        {
            var user = await usuarioRepository.GetById(request.UserId);

            if (user is null)
            {
                return Results.NotFound();
            }

            var serializedIntereses = JsonSerializer.Serialize(request.Intereses);

            user.Update(
              request.Nombre,
              request.Apellido,
              DateTime.SpecifyKind(request.FechaNacimiento, DateTimeKind.Utc),
              request.Distrito,
              request.Colegio,
              serializedIntereses,
              request.Sexo
            );

            await dbContext.SaveChangesAsync();

            return Results.Ok();

        }).WithTags(Tags.Usuarios);

        app.MapPost("login", async (
            LoginRequest request,
            IUsuarioRepository usuarioRepository,
            IJwtTokenGenerator jwtTokenGenerator) =>
        {
            var userExist = await usuarioRepository.GetByEmailAsync(request.Correo);

            if (userExist is null)
            {
                return Results.NotFound();
            }

            var token = jwtTokenGenerator.GenerateToken(userExist);

            return Results.Ok(token);


        }).WithTags(Tags.Usuarios);

        app.MapPost("register", async (
            RegisterRequest request,
            IUsuarioRepository usuarioRepository,
            CancellationToken cancellationToken) =>
        {
            var userExist = await usuarioRepository.GetByEmailAsync(request.Correo);

            if (userExist is not null)
            {
                return Results.Conflict("Ya existe una cuenta con este correo");
            }

            var password = BC.HashPassword(request.Password);

            var serializedIntereses = JsonSerializer.Serialize(request.Intereses);

            var usuario = new Usuario
            {
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Correo = request.Correo,
                Password = password,
                FechaNacimiento = DateTime.SpecifyKind(request.FechaNacimiento, DateTimeKind.Utc),
                Distrito = request.Distrito,
                Colegio = request.Colegio,
                Sexo = request.Sexo,
                Historial = "[]",
                Intereses = serializedIntereses,
                CreatedOnUtc = DateTime.UtcNow,
            };

            await usuarioRepository.SaveAsync(usuario, cancellationToken);

            return Results.Ok();

        }).WithTags(Tags.Usuarios);
    }
}

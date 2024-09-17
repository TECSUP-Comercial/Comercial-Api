using System.Data.Common;
using System.Text.Json;
using Comercial.Api.Contracts.Medias;
using Comercial.Api.Database;
using Comercial.Api.Models;
using Comercial.Api.Repository;
using Comercial.Api.Services.FileStorage;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace Comercial.Api.Endpoints;

public static class MediaEndpoints
{
    public static void MapMediaEndpoints(this IEndpointRouteBuilder app)
    {

        app.MapGet("media/info/{mediaId}", async (Guid mediaId, ISeccionRepository seccionRepository) =>
        {
            var media = await seccionRepository.GetMediaDatosAsync(mediaId);

            if (media is null)
            {
                return Results.NotFound("El contendo media no existe");
            }

            return Results.Ok(new MediaResponse(
                media.Likes,
                media.Description,
                media.Comentarios,
                media.Categorias,
                media.UrlMedia,
                media.Duracion
            ));
        });


        app.MapGet("media/", (
            string urlMedia,
            [FromServices] IFileStorageLocal _fileStorageLocal,
            [FromServices] IWebHostEnvironment _env) =>
        {

            var fileStream = _fileStorageLocal.GetFile(urlMedia, _env.WebRootPath);

            if (fileStream == null)
            {
                return Results.NotFound("Archivo no encontrado.");
            }

            return Results.File(fileStream, "application/octet-stream");

        }).WithTags(Tags.Media);

        app.MapGet("seccion/{seccionId}", async (
            Guid seccionId,
            [FromServices] IDbConnectionFactory dbConnectionFactory) =>
        {
            await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

            var parameters = new MediaParameters(seccionId);

            IReadOnlyCollection<MediaResponse> seccion = await GetSeccionAsync(connection, parameters);

            return Results.Ok(seccion);

        }).WithTags(Tags.Media);

        app.MapPost("media/{mediaId}/likes", async (
            Guid mediaId,
            Guid userId,
            ISeccionRepository seccionRepository,
            ApplicationDbContext context) =>
        {
            var mediaDatos = await seccionRepository.GetLikeAsync(mediaId);

            if (mediaDatos is null)
            {
                return Results.NotFound("Media no encontrada.");
            }

            var likes = string.IsNullOrEmpty(mediaDatos)
                ? []
                : JsonSerializer.Deserialize<Dictionary<string, bool>>(mediaDatos);

            likes ??= [];

            if (likes.ContainsKey(userId.ToString()))
            {
                likes[userId.ToString()] = !likes[userId.ToString()];
            }
            else
            {
                likes[userId.ToString()] = true;
            }

            mediaDatos = JsonSerializer.Serialize(likes);

            await context.SaveChangesAsync();

            return Results.Ok(new
            {
                MediaId = mediaId,
                Likes = likes
            });
        }).WithTags(Tags.Media);

        app.MapPost("comment/add", async (
            Guid mediaId,
            Guid usuarioId,
            string nombreUsuario,
            string comentarioTexto,
            ISeccionRepository seccionRepository,
            ApplicationDbContext context) =>
        {
            var comentarios = await seccionRepository.GetComentariosAsync(mediaId);

            if (comentarios is null)
            {
                return Results.NotFound("Media no encontrada.");
            }

            var data = string.IsNullOrEmpty(comentarios)
                ? []
                : JsonSerializer.Deserialize<List<Comentario>>(comentarios);

            data ??= [];

            var nuevoComentario = new Comentario
            {
                Usuario = nombreUsuario,
                Texto = comentarioTexto,
                Fecha = DateTime.UtcNow
            };

            data.Add(nuevoComentario);

            comentarios = JsonSerializer.Serialize(data);

            await context.SaveChangesAsync();

            return Results.Ok(new
            {
                MediaId = mediaId,
                Comentarios = data
            });
        }).WithTags(Tags.Media);

    }

    private static async Task<IReadOnlyCollection<MediaResponse>> GetSeccionAsync(
        DbConnection connection,
        MediaParameters parameters
    )
    {
        const string sql = """
            SELECT 
        """;

        List<MediaResponse> medias = (await connection.QueryAsync<MediaResponse>(sql, parameters)).AsList();

        return medias;
    }
    private sealed record MediaParameters(Guid MediaId);
}

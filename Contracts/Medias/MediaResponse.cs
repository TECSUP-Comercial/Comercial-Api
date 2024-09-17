namespace Comercial.Api.Contracts.Medias;

public sealed record MediaResponse(
    string Likes,
    string Descripcion,
    string Comentarios,
    string Categorias,
    string UrlMedia,
    string Duracion
);

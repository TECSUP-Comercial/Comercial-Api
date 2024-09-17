using Comercial.Api.Models;

namespace Comercial.Api.Repository;

public interface ISeccionRepository
{
    Task<Seccion?> GetSeccionAsync(Guid seccionId);
    Task<string?> GetComentariosAsync(Guid mediaId);
    Task<string?> GetLikeAsync(Guid mediaId);
    Task<MediaDatos?> GetMediaDatosAsync(Guid mediaId);
}

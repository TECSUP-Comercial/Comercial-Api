using Comercial.Api.Database;
using Comercial.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Comercial.Api.Repository;

public class SeccionRepository(ApplicationDbContext dbContext) : ISeccionRepository
{
    public async Task<string?> GetLikeAsync(Guid mediaId)
    {
        return await dbContext.MediaDatos
            .Where(m => m.Id == mediaId)
            .Select(m => m.Likes)
            .SingleOrDefaultAsync();
    }

    public async Task<string?> GetComentariosAsync(Guid mediaId)
    {
        return await dbContext.MediaDatos
            .Where(m => m.Id == mediaId)
            .Select(m => m.Comentarios)
            .SingleOrDefaultAsync();
    }

    public async Task<Seccion?> GetSeccionAsync(Guid seccionId)
    {
        return await dbContext.Seccions.SingleOrDefaultAsync(s => s.Id == seccionId);
    }

    public async Task<MediaDatos?> GetMediaDatosAsync(Guid mediaId)
    {
        return await dbContext.MediaDatos.SingleOrDefaultAsync(m => m.Id == mediaId);
    }
}

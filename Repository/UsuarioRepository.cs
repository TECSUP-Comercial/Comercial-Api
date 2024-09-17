using Comercial.Api.Database;
using Comercial.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Comercial.Api.Repository;

public class UsuarioRepository(ApplicationDbContext dbContext) : IUsuarioRepository
{
    public async Task<Usuario?> GetByEmailAsync(string Correo)
    {
        return await dbContext.Usuarios
            .Where(u => u.Correo == Correo)
            .FirstOrDefaultAsync();
    }

    public async Task<Usuario?> GetById(Guid userId)
    {
        return await dbContext.Usuarios.SingleOrDefaultAsync(a => a.Id == userId);
    }

    public async Task SaveAsync(Usuario usuario, CancellationToken cancellationToken)
    {
        dbContext.Add(usuario);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}

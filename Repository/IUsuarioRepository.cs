using Comercial.Api.Models;

namespace Comercial.Api.Repository;

public interface IUsuarioRepository
{
    Task SaveAsync(Usuario usuario,CancellationToken cancellationToken);
    Task<Usuario?> GetById(Guid userId);
    Task<Usuario?> GetByEmailAsync(string Correo);
}

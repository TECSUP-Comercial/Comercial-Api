using Comercial.Api.Models;

namespace Comercial.Api.Services.Jwt;

public interface IJwtTokenGenerator
{
    string GenerateToken(Usuario usuario);
}
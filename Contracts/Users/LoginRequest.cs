namespace Comercial.Api.Contracts.Users;

public sealed record LoginRequest(
    string Correo,
    string Password
);
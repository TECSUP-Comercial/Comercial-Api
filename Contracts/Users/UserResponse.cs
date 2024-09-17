namespace Comercial.Api.Contracts.Users;

public sealed record UserResponse(
    Guid UserId,
    string Nombre,
    string Apellido,
    DateTime FechaNacimiento,
    string Distrito,
    string Colegio,
    string Historial,
    string Interes,
    string Sexo
);


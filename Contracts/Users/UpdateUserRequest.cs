namespace Comercial.Api.Contracts.Users;

public sealed record UpdateUserRequest(
    Guid UserId,
    string Nombre,
    string Apellido,
    DateTime FechaNacimiento,
    string Distrito,
    string Colegio,
    List<string> Intereses,
    string Sexo
);

namespace Comercial.Api.Contracts.Users;

public sealed record RegisterRequest(
    string Nombre,
    string Apellido,
    string Correo,
    string Password,
    DateTime FechaNacimiento,
    string Distrito,
    string Colegio,
    string Sexo,
    List<string> Intereses
);
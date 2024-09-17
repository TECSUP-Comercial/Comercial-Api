namespace Comercial.Api.Models;

public class VideoHistorial
{
    public Guid VideoId { get; set; }
    public DateTime FechaVisto { get; set; }
    public int Progreso { get; set; }
}

public sealed class Usuario : BaseEntity
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public string Distrito { get; set; } = string.Empty;
    public string Colegio { get; set; } = string.Empty;
    public string Intereses { get; set; } = string.Empty;
    public string Historial { get; set; } = string.Empty;
    public string Sexo { get; set; } = string.Empty;


    public void Update(
        string nombre,
        string apellido,
        DateTime fechaNacimiento,
        string distrito,
        string colegio,
        string intereses,
        string sexo
    )
    {
        if (
            nombre == Nombre
            && apellido == Apellido
            && fechaNacimiento == FechaNacimiento
            && distrito == Distrito
            && colegio == Colegio
            && intereses == Intereses
            && sexo == Sexo
        )
        {
            return;
        }

        Nombre = nombre;
        Apellido = apellido;
        FechaNacimiento = fechaNacimiento;
        Distrito = distrito;
        Colegio = colegio;
        Intereses = intereses;
        Sexo = sexo;
    }
}

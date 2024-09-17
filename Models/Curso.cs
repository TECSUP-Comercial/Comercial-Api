namespace Comercial.Api.Models;

public sealed class Curso : BaseEntity
{
    private readonly List<Seccion> seccions = [];
    public string Nombre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Dificultad { get; set; } = string.Empty;
    public string Categorias { get; set; } = string.Empty;
    public string LinkImage { get; set; } = string.Empty;
    public string DescripcionFinal { get; set; } = string.Empty;
    public int Duracion { get; set; }
}

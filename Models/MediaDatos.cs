namespace Comercial.Api.Models;

public class Comentario
{
    public string Usuario { get; set; } = string.Empty;
    public string Texto { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
}


public sealed class MediaDatos : BaseEntity
{
    private readonly List<Seccion> secciones = [];

    public string UrlMedia { get; set; } = string.Empty;
    public string Likes { get; set; } = string.Empty;
    public string TipoMedia { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Comentarios { get; set; } = string.Empty;
    public string Categorias { get; set; } = string.Empty;
    public bool IsReel { get; set; }
    public string Duracion { get; set; } = string.Empty;
}


namespace Comercial.Api.Models;

public sealed class ProgressCurso : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid CursoId { get; set; }
    public DateTime FechaInicio { get; set; }
    public int PorcentajeAvanzado { get; set; }
    public string UrlEntregable { get; set; } = string.Empty;
    public string SeccionesCompletadas { get; set; } = string.Empty;
    public int CantidadSesiones { get; set; }
}

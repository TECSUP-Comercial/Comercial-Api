namespace Comercial.Api.Models;

public sealed class Seccion : BaseEntity
{
    public Guid CursoId { get; set; }
    public Guid? SeccionPadreId { get; set; }
    public Guid MediaId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int NumeroOrden { get; set; }
}

namespace Comercial.Api.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedOnUtc { get; set; }
}

using Comercial.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comercial.Api.Database.Configuration;

public class SeccionConfiguration : IEntityTypeConfiguration<Seccion>
{
    public void Configure(EntityTypeBuilder<Seccion> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasOne<Curso>()
            .WithMany()
            .HasForeignKey(s => s.CursoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Seccion>()
            .WithMany()
            .HasForeignKey(s => s.SeccionPadreId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<MediaDatos>()
            .WithMany()
            .HasForeignKey(s => s.MediaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(s => s.Nombre)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(s => s.Description).HasColumnType("text");

        builder.Property(s => s.NumeroOrden)
            .IsRequired();
    }
}


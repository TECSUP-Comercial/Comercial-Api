using System;
using Comercial.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comercial.Api.Database.Configuration;

public class ProgressCursoConfiguration : IEntityTypeConfiguration<ProgressCurso>
{
    public void Configure(EntityTypeBuilder<ProgressCurso> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.CursoId).IsRequired();

        builder.Property(x => x.FechaInicio)
            .IsRequired();

        builder.Property(x => x.PorcentajeAvanzado)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(x => x.UrlEntregable)
            .HasMaxLength(500);

        builder.Property(x => x.SeccionesCompletadas)
            .HasColumnType("jsonb");

        builder.Property(x => x.CantidadSesiones)
            .HasDefaultValue(0)
            .IsRequired();
    }
}

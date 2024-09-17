using Comercial.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Comercial.Api.Database.Configuration;

public class CursoConfiguration : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nombre)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnType("text");

        builder.Property(x => x.Autor)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Dificultad)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Categorias)
            .HasColumnType("jsonb");

        builder.Property(x => x.LinkImage)
            .HasMaxLength(500);

        builder.Property(x => x.DescripcionFinal)
            .HasColumnType("text");

        builder.Property(x => x.Duracion)
            .IsRequired();
    }
}

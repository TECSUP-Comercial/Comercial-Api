using System.Text.Json;
using System.Text.Json.Serialization;
using Comercial.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comercial.Api.Database.Configuration;

public class MediaDatosConfiguration : IEntityTypeConfiguration<MediaDatos>
{
    public void Configure(EntityTypeBuilder<MediaDatos> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UrlMedia)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.Likes)
            .HasColumnType("jsonb");

        builder.Property(x => x.TipoMedia)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnType("text");

        builder.Property(x => x.Comentarios)
            .HasColumnType("jsonb");

        builder.Property(x => x.Categorias)
            .HasColumnType("jsonb");

        builder.Property(x => x.Duracion)
            .HasConversion(v => v.ToString(), v => TimeSpan.Parse(v));
    }
}



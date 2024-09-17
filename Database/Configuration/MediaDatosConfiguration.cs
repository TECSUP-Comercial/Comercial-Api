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
            .IsRequired();
        ;

        builder.HasData(
            new MediaDatos
            {
                Id = Guid.NewGuid(),
                UrlMedia = "video.mp4",
                Likes = "[{\"userId\": \"123\", \"like\": true}, {\"userId\": \"456\", \"like\": false}]",
                TipoMedia = "Video",
                Description = "Este es el primer video de ejemplo.",
                Comentarios = "[{\"usuario\": \"Juan\", \"texto\": \"Buen video!\", \"fecha\": \"2024-08-25T14:30:00\"}]",
                Categorias = "[\"Educación\", \"Tutorial\"]",
                IsReel = false,
                Duracion = "5:00"
            },
            new MediaDatos
            {
                Id = Guid.NewGuid(),
                UrlMedia = "prueba.png",
                Likes = "[{\"userId\": \"789\", \"like\": true}]",
                TipoMedia = "Video",
                Description = "Este es el segundo video de ejemplo.",
                Comentarios = "[{\"usuario\": \"Maria\", \"texto\": \"Muy informativo!\", \"fecha\": \"2024-08-26T10:15:00\"}]",
                Categorias = "[\"Tecnología\", \"Programación\"]",
                IsReel = true,
                Duracion = "5:00"
            });

    }
}



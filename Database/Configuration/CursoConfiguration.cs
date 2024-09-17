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

        builder.HasData(
            new Curso
            {
                Id = Guid.NewGuid(),
                Nombre = "Curso de Programación en C#",
                Description = "Un curso completo sobre desarrollo de aplicaciones con C# y .NET.",
                Autor = "Juan Pérez",
                Dificultad = "Intermedio",
                Categorias = "Programación, Desarrollo",
                LinkImage = "video.mp4",
                DescripcionFinal = "Este curso te enseñará desde lo básico hasta temas avanzados de C#.",
                Duracion = 40
            },
        new Curso
        {
            Id = Guid.NewGuid(),
            Nombre = "Curso de Desarrollo Web con JavaScript",
            Description = "Aprende a desarrollar aplicaciones web interactivas usando JavaScript y frameworks modernos.",
            Autor = "Maria López",
            Dificultad = "Avanzado",
            Categorias = "Desarrollo Web, JavaScript",
            LinkImage = "prueba.png",
            DescripcionFinal = "Al final del curso serás capaz de crear sitios web dinámicos y escalables.",
            Duracion = 50
        });
    }
}

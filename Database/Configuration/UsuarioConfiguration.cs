using Comercial.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comercial.Api.Database.Configuration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nombre).HasMaxLength(255);
        builder.Property(x => x.Apellido).HasMaxLength(255);
        builder.Property(x => x.Correo).HasMaxLength(300);
        builder.Property(x => x.Colegio).HasMaxLength(255);
        builder.Property(x => x.Distrito).HasMaxLength(255);
        builder.Property(x => x.Sexo).HasMaxLength(50);

        builder.Property(x => x.Intereses)
            .HasColumnType("jsonb");

        builder.Property(x => x.Historial)
            .HasColumnType("jsonb");
    }
}


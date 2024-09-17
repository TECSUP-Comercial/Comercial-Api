using Comercial.Api.Database.Configuration;
using Comercial.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Comercial.Api.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    internal DbSet<Curso> Cursos { get; set; }
    internal DbSet<Usuario> Usuarios { get; set; }
    internal DbSet<MediaDatos> MediaDatos { get; set; }
    internal DbSet<ProgressCurso> ProgressCursos { get; set; }
    internal DbSet<Seccion> Seccions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CursoConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        modelBuilder.ApplyConfiguration(new MediaDatosConfiguration());
        modelBuilder.ApplyConfiguration(new ProgressCursoConfiguration());
        modelBuilder.ApplyConfiguration(new SeccionConfiguration());
    }

}

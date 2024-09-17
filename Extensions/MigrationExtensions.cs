using Comercial.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace Comercial.Api.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        using var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

        dbContext?.Database.Migrate();
    }
}

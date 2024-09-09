using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.DLL.DbContext;

namespace UniversityManagementSystem.API.StartupExtension;

public static class DatabaseExtensionHelper
{
    public static IServiceCollection AddDatabaseExtensionHelper(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }


    // Run migration in database when starting the project only in development
    public static IApplicationBuilder RunMigration(
        this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            db.Database.Migrate();
        }
        return app;
    }
}

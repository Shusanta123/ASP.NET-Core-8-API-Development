using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.API.DbContext;

namespace UniversityManagementSystem.API.StartupExtension;

public static class DatabaseExtensionHelper
{
    public static IServiceCollection AddDatabaseExtensionHelper(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}

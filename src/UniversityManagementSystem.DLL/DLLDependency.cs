﻿using Microsoft.Extensions.DependencyInjection;
using UniversityManagementSystem.DLL.Repository;

namespace UniversityManagementSystem.DLL;

public static class DLLDependency
{
    public static IServiceCollection AddDLLDependency(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();


        return services;
    }
}

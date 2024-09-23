using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.BLL.Service;
using UniversityManagementSystem.DLL.Repository;

namespace UniversityManagementSystem.BLL;

public static class BLLDependency
{
    public static IServiceCollection AddBLLDependency(this IServiceCollection services)
    {
       services.AddScoped<ICategoryService, CategoryService>();
       services.AddScoped<IProductService, ProductService>();


        return services;
    }
}

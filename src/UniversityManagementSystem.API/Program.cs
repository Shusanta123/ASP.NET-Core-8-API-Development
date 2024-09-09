using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.DLL.DbContext;
using UniversityManagementSystem.API.StartupExtension;
using UniversityManagementSystem.BLL.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseExtensionHelper(builder.Configuration); // database configuration
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();



// Dependency load


var app = builder.Build();


// Middleware load

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.RunMigration(); // Run migration in database when starting the project only in development
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

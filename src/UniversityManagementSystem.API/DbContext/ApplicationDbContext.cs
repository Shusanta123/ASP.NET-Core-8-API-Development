using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.API.Model;

namespace UniversityManagementSystem.API.DbContext;

    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }


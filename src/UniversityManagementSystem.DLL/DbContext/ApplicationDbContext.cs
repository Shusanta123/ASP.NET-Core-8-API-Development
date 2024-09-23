using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.DLL.Models;

namespace UniversityManagementSystem.DLL.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure many-to-many relationship
        modelBuilder.Entity<CategoryProduct>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });

        modelBuilder.Entity<CategoryProduct>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.CategoryProducts)
            .HasForeignKey(pc => pc.ProductId);

        modelBuilder.Entity<CategoryProduct>()
            .HasOne(pc => pc.Category)
        .WithMany(c => c.CategoryProducts)
            .HasForeignKey(pc => pc.CategoryId);
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Category>()
    //        .HasMany(c => c.CategoryProducts)
    //        .WithOne(e => e.Category).
    //        .IsRequired();
    //}


    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CategoryProduct> CategoryProducts { get; set; }

}

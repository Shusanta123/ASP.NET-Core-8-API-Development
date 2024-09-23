using UniversityManagementSystem.DLL.DbContext;
using UniversityManagementSystem.DLL.Models;

namespace UniversityManagementSystem.DLL.Repository;


//Implement IrepositoryBase and this repository will only work with product
public interface IProductRepository : IRepositoryBase<Product>
{
}


// c# does not support multiple inheritance But 
// support multiple interface
// tell repository to only send product
// Extend repositoryBase and Implement IProductRepository

// Now Inject the repository

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}

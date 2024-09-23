using UniversityManagementSystem.DLL.DbContext;
using UniversityManagementSystem.DLL.Models;

namespace UniversityManagementSystem.DLL.Repository;


//Implement IrepositoryBase and this repository will only work with Category
public interface ICategoryRepository : IRepositoryBase<Category>
{
}


// c# does not support multiple inheritance But 
// support multiple interface
// tell repository to only send category
// Extend repositoryBase and Implement ICategoryRepository

// Now Inject the repository

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}


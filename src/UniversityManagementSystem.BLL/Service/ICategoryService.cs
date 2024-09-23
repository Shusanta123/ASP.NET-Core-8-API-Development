using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UniversityManagementSystem.BLL.ViewModel.Request;
using UniversityManagementSystem.DLL.DbContext;
using UniversityManagementSystem.DLL.Models;
using UniversityManagementSystem.DLL.Repository;

namespace UniversityManagementSystem.BLL.Service;

public interface ICategoryService
{
    Task<List<Category>> GetAll();
    Task<Category> GetAData(int id);
    Task<Category> AddCategory(Category category);
    Task<Category> UpdateCategory(int id, CategoryInsertViewModel request);
    Task<Category> DeleteCategory(int id);
}



public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    
    public async Task<List<Category>> GetAll()
    {
        return await _categoryRepository.FindAll().ToListAsync();
    }
    public async Task<Category> GetAData(int id)
    {
        return await _categoryRepository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
    }


    public async Task<Category> AddCategory(Category category)
    {
        _categoryRepository.Create(category);

        if (await _categoryRepository.SaveChangesAsync())
        {
            return category;
        }

        throw new Exception("something went wrong");
    }

    public async Task<Category> UpdateCategory(int id, CategoryInsertViewModel request)
    {
        var category = await GetAData(id);

        if (category == null)
        {
            throw new Exception("category not found");
        }

        if (!request.Name.IsNullOrEmpty())
        {
            category.Name = request.Name;
        }

        if (!request.ShortName.IsNullOrEmpty())
        {
            category.ShortName = request.ShortName;
        }

        _categoryRepository.Update(category);

        if (await _categoryRepository.SaveChangesAsync())
        {
            return category;
        }

        throw new Exception("something went wrong");
    }

    public async Task<Category> DeleteCategory(int id)
    {
        var category = await GetAData(id);

        if (category == null)
        {
            throw new Exception("category not found");
        }

        _categoryRepository.Delete(category);

        if (await _categoryRepository.SaveChangesAsync())
        {
            return category;
        }

        throw new Exception("something went wrong");
    }
}

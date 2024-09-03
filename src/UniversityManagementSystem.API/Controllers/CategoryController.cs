using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.API.DbContext;
using UniversityManagementSystem.API.Model;
using UniversityManagementSystem.API.ViewModel.Request;

namespace UniversityManagementSystem.API.Controllers;


public class CategoryController : ApiBaseController
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _dbContext.Categories.AsQueryable().ToListAsync();
        return Ok(categories);
    }
    

    [HttpGet("id")]
    public async Task<IActionResult>  GetAData(int id)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        return Ok(category);
    }


    [HttpPost]
    public async Task<IActionResult> Insert(CategoryInsertViewModel request)
    {
        var category = new Category()
        {
            Name = request.Name
        };

        _dbContext.Categories.Add(category);

        if(await _dbContext.SaveChangesAsync()>0)
        {
            return Ok(category);
        }
        return NotFound("data Insert error");
        
    }


    [HttpPut("id")]
    public async Task<IActionResult> Update(int id, CategoryInsertViewModel request)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

        if(category == null)
        {
            return NotFound("data Not Found");
        }

        category.Name = request.Name;

        _dbContext.Categories.Update(category);

        if (await _dbContext.SaveChangesAsync() > 0)
        {
            return Ok(category);
        }
        return NotFound("data Update error");
    }

    [HttpDelete("id")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

        if (category == null)
        {
            return NotFound("data Not Found");
        }

        _dbContext.Categories.Remove(category);

        if (await _dbContext.SaveChangesAsync() > 0)
        {
            return Ok("Delete was Successful");
        }
        return NotFound("data Delete error");
    }

}

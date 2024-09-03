using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.API.DbContext;
using UniversityManagementSystem.API.Model;
using UniversityManagementSystem.API.ViewModel.Request;

namespace UniversityManagementSystem.API.Controllers;


public class ProductController : ApiBaseController
{
    private readonly ApplicationDbContext _dbContext;

    public ProductController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _dbContext.Products.AsQueryable().ToListAsync();
        return Ok(products);
    }


    [HttpGet("id")]
    public async Task<IActionResult> GetAData(int id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (product == null)
        {
            return NotFound("data Not Found");
        }
        return Ok(product);
    }


    [HttpPost]
    public async Task<IActionResult> Insert(ProductInsertViewModel request)
    {
        var product = new Product()
        { 
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        _dbContext.Products.Add(product);

        if (await _dbContext.SaveChangesAsync() > 0)
        {
            return Ok(product);
        }
        return NotFound("data Insert error");

    }


    [HttpPut("id")]
    public async Task<IActionResult> Update(int id, ProductInsertViewModel request)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product == null)
        {
            return NotFound("data Not Found");
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;

        _dbContext.Products.Update(product);

        if (await _dbContext.SaveChangesAsync() > 0)
        {
            return Ok(product);
        }
        return NotFound("data Update error");
    }

    [HttpDelete("id")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product == null)
        {
            return NotFound("data Not Found");
        }

        _dbContext.Products.Remove(product);

        if (await _dbContext.SaveChangesAsync() > 0)
        {
            return Ok("Delete was Successful");
        }
        return NotFound("data Delete error");
    }
}

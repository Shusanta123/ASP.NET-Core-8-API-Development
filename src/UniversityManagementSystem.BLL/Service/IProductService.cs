using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementSystem.DLL.Models;
using UniversityManagementSystem.BLL.ViewModel.Request;
using UniversityManagementSystem.DLL.DbContext;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using Microsoft.IdentityModel.Tokens;
namespace UniversityManagementSystem.BLL.Service;

public interface IProductService
{
    Task<List<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);

    Task<Product> InsertProduct(Product product);

    Task<Product> UpdateProduct(int id, ProductInsertViewModel product);

    Task<Product> DeleteProduct(int id);
}

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context) 
    {
        _context = context;
    }


    public async Task<List<Product>> GetAllProducts()
    {
       return await _context.Products.AsQueryable().ToListAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
       return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product> InsertProduct(Product product)
    {
         _context.Products.Add(product);

        if (await _context.SaveChangesAsync() > 0)
        {
            return product;
        }

        throw new Exception("something went wrong");
    }

    public async Task<Product> UpdateProduct(int id, ProductInsertViewModel request)
    {
        var product = await GetProductById(id);

        if (product == null)
        {
            throw new Exception("category not found");
        }

        if (!request.Name.IsNullOrEmpty())
        {
            product.Name = request.Name;
        }

        if (!request.Description.IsNullOrEmpty())
        {
            product.Description = request.Description;
        }

        _context.Products.Update(product);

        if (await _context.SaveChangesAsync() > 0)
        {
            return product;
        }

        throw new Exception("something went wrong");
    }
    public async Task<Product> DeleteProduct(int id)
    {
        var product = await GetProductById(id);

        if (product == null)
        {
            throw new Exception("category not found");
        }

        _context.Products.Remove(product);

        if (await _context.SaveChangesAsync() > 0)
        {
            return product;
        }
        throw new Exception("something went wrong");
    }

}
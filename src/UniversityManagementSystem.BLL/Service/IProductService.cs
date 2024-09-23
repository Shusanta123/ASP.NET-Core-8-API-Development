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
using UniversityManagementSystem.DLL.Repository;
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
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository) 
    {
        _productRepository = productRepository;
    }


    public async Task<List<Product>> GetAllProducts()
    {
       return await _productRepository.FindAll().ToListAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
       return await _productRepository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Product> InsertProduct(Product product)
    {
         _productRepository.Create(product);

        if (await _productRepository.SaveChangesAsync())
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

        _productRepository.Update(product);

        if (await _productRepository.SaveChangesAsync())
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

        _productRepository.Delete(product);

        if (await _productRepository.SaveChangesAsync())
        {
            return product;
        }
        throw new Exception("something went wrong");
    }

}
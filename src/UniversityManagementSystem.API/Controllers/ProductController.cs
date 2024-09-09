using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.DLL.DbContext;
using UniversityManagementSystem.DLL.Models;
using UniversityManagementSystem.BLL.ViewModel.Request;
using UniversityManagementSystem.BLL.Service;

namespace UniversityManagementSystem.API.Controllers;


public class ProductController : ApiBaseController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _productService.GetAllProducts());
    }


    [HttpGet("id")]
    public async Task<IActionResult> GetAData(int id)
    {
        return Ok(await _productService.GetProductById(id));
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
        return Ok(await _productService.InsertProduct(product));

    }

    [HttpPut("id")]
    public async Task<IActionResult> Update(int id, ProductInsertViewModel request)
    {
        return Ok(await _productService.UpdateProduct(id, request));
    }

    [HttpDelete("id")]
    public async Task<IActionResult> Delete(int id)
    {
       return Ok(await _productService.DeleteProduct(id));
    }
}

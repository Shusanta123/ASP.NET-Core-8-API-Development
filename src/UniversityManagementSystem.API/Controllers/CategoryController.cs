using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.DLL.Models;
using UniversityManagementSystem.BLL.Service;
using UniversityManagementSystem.BLL.ViewModel.Request;

namespace UniversityManagementSystem.API.Controllers;


public class CategoryController : ApiBaseController
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _categoryService.GetAll());
    }
    

    [HttpGet("id")]
    public async Task<IActionResult>  GetAData(int id)
    {   
        return Ok(await _categoryService.GetAData(id));
    }


    [HttpPost]
    public async Task<IActionResult> Insert(CategoryInsertViewModel request)
    {
        var category = new Category() //Create new object of DLL Category model
        {
            Name = request.Name, // Insert request going through BLL ViewModel to DLL
            ShortName = request.ShortName
        };

        return Ok(await _categoryService.AddCategory(category));
        
    }


    [HttpPut("id")]
    public async Task<IActionResult> Update(int id, CategoryInsertViewModel request)
    {
        return Ok(await _categoryService.UpdateCategory(id, request));
    }

    [HttpDelete("id")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _categoryService.DeleteCategory(id));
    }

}

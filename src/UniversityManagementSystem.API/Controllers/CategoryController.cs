using Microsoft.AspNetCore.Mvc;

namespace UniversityManagementSystem.API.Controllers
{

    public class CategoryController : ApiBaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("All category is here");
        }
    }
}

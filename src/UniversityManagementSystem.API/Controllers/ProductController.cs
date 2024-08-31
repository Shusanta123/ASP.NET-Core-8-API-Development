using Microsoft.AspNetCore.Mvc;

namespace UniversityManagementSystem.API.Controllers
{

    public class ProductController : ApiBaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Product is here");
        }
    }
}

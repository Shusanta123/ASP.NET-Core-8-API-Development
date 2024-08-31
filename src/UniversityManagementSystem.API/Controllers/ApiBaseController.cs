using Microsoft.AspNetCore.Mvc;

namespace UniversityManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiBaseController : ControllerBase  // abstract so no class can be made of this class
    {
        
    }
}

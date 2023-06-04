using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LabController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }
    }
}

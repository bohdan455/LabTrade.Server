using BLL.Dto.Lab;
using BLL.ExtensionMethods.Mapping;
using BLL.Services.Interfaces;
using DataAccess.Repositories.Realizations.Lab;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //TODO Add authorize
    public class LabController : ControllerBase
    {
        private readonly ILabWorkService _labWorkService;

        public LabController(ILabWorkService labWorkService)
        {
            _labWorkService = labWorkService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] LabWorkDto labWorkDto)
        {
            await _labWorkService.Create(labWorkDto);
            return Ok();
        }
    }
}

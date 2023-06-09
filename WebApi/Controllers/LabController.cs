﻿using BLL.Dto.Lab;
using BLL.ExtensionMethods.Mapping;
using BLL.Services.Interfaces;
using DataAccess.Repositories.Realizations.Lab;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] LabWorkDto labWorkDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            
            await _labWorkService.CreateAsync(labWorkDto, User);
            return Ok();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        //TODO delete\fix fromfrom
        public async Task<IActionResult> DeleteAsync([FromForm]int id)
        {
            var result = await _labWorkService.DeleteAsync(id, User);
            if (result)
            {
                return Ok();
            }
            else
            {
                //TODO disable redirection
                return Forbid();
            }
        }
        //TODO Add update endpoint

        [HttpGet("{page:int}/{elementsPerPage:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInRangeAsync(int page, int elementsPerPage)
        {
            var result =_labWorkService.GetRange(page, elementsPerPage);
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _labWorkService.GetByIdAsync(id);
            if (result is null) return NotFound();
            return Ok(result);
        }
    }
}

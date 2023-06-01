using BLL.Dto.Users;
using BLL.ExtensionMethods.Mapping;
using BLL.Services.Interfaces;
using BLL.Services.Realizations.Jwt;
using DataAccess.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<Seller> _signInManager;
        private readonly UserManager<Seller> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginController(SignInManager<Seller> signInManager,UserManager<Seller> userManager,IJwtTokenService jwtTokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }
        [HttpPost]
        public async Task<IActionResult> LoginWithPassword([FromForm]SellerLoginDto sellerLoginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var seller = await _userManager.FindByNameAsync(sellerLoginDto.Login);
            var result = await _signInManager.CheckPasswordSignInAsync(seller, sellerLoginDto.Password,false);
            if (result.Succeeded)
            {
                var token = _jwtTokenService.GenerateToken();
                return Ok(new {token});
            }
            else
            {
                return NotFound();
            }
        }
    }
}

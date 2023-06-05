using BLL.Dto.Errors;
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
    [AllowAnonymous]
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
        [HttpPost("password")]
        public async Task<IActionResult> LoginWithPassword([FromForm]SellerLoginDto sellerLoginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var seller = await _userManager.FindByNameAsync(sellerLoginDto.Login);
            if (seller is null)
            {
                return BadRequest(new ErrorResponceMessage
                {
                    Error = "Auth-0001",
                    Message = "Incorrect login or password",
                    Details = "Ensure that the username and password included in the request are correct"
                });
            }
            var result = await _signInManager.CheckPasswordSignInAsync(seller, sellerLoginDto.Password,true);
            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, seller.UserName)
                };
                var token = _jwtTokenService.GenerateToken(claims);
                return Ok(new {token});
            }
            else if (result.IsLockedOut)
            {
                return BadRequest(new ErrorResponceMessage
                {
                    Error = "Auth-0002",
                    Message = "Too many attempts",
                    Details = "Try later"
                });
            }
            else
            {
                return BadRequest(new ErrorResponceMessage
                {
                    Error = "Auth-0001",
                    Message="Incorrect login or password",
                    Details="Ensure that the username and password included in the request are correct"
                });
            }
        }
    }
}

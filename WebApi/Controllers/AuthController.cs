using BLL.Dto.Users;
using DataAccess.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Seller> _userManager;

        public AuthController(UserManager<Seller> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromForm]SellerRegistrationDto sellerRegistrationDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var seller = new Seller
            {
                UserName = sellerRegistrationDto.Login,
                Email = sellerRegistrationDto.Email,
            };
            var result = await _userManager.CreateAsync(seller, sellerRegistrationDto.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                }
                return BadRequest(ModelState);
            }
        }
    }
}

using IRWalks.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IRWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };
            var identityresult = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);
            if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
            {
                foreach (var role in registerRequestDto.Roles)
                {
                    var roleResult = await _userManager.AddToRoleAsync(identityUser, role);
                    if (!roleResult.Succeeded)
                    {
                        return BadRequest("Failed to add roles.");
                    }
                }

                return Ok("User was registered! Please login.");
            }
            return BadRequest("Something Went Wrong");
        }
    }
}

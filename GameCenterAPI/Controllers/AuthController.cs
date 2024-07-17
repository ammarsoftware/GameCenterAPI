
using GameCenterAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameCenterAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login/")]

        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var response = await _authService.LoginAsync(model.username, model.password);
            if (response == null)
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }
            return Ok(response);
        }
    }
}

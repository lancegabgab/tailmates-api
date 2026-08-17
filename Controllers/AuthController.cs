using Microsoft.AspNetCore.Mvc;
using TailMates.Models.Inputs;
using TailMates.Services;

namespace TailMates.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserInput input)
        {
            var user = await _authService.RegisterAsync(input);

            return Ok(user);
        }
    }
}
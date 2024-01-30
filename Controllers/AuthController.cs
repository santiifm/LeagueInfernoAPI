using league_inferno_api.DTOs;
using league_inferno_api.Interfaces;
using league_inferno_api.Models;
using league_inferno_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace league_inferno_api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsersRepository _userRepo;
        private readonly JwtService _tokenService;

        public AuthController(IUsersRepository userRepo, JwtService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> LoginAsync(UserDTO user)
        {
            try
            {
                var authenticatedUser = await _userRepo.AuthenticateAsync(user.Username, user.Password);

                if (authenticatedUser == null)
                {
                    return Unauthorized(new { message = "Invalid credentials" });
                }

                var token = _tokenService.GenerateToken(authenticatedUser.Username);

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> RegisterAsync(UserDTO user)
        {
            try
            {
                var registeredUser = await _userRepo.RegisterAsync(user.Username, user.Password);

                if (registeredUser == null)
                {
                    return Unauthorized(new { message = "Invalid credentials" });
                }

                var token = _tokenService.GenerateToken(user.Username);

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return StatusCode(403, new { message = ex.Message});
            }
        }
    }
}
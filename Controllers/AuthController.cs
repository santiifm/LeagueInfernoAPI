using league_inferno_api.DTOs;
using league_inferno_api.Interfaces;
using league_inferno_api.Models;
using league_inferno_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace league_inferno_api.Controllers
{
    using System.Reflection;
    using BCrypt.Net;
    using Microsoft.AspNetCore.Authorization;

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
        [ProducesResponseType(200, Type = typeof(UserAuthDTO))]
        public async Task<IActionResult> Login(UserDTO user)
        {
            try
            {
                var authenticatedUser = await _userRepo.AuthenticateAsync(user.Username);

                _ = BCrypt.Verify(user.Password, authenticatedUser.PasswordHash) ? true : throw new Exception($"Incorrect password");

                var token = _tokenService.GenerateToken(authenticatedUser);

                return Ok(new UserAuthDTO {
                    Username = authenticatedUser.Username,
                    Token = token
                });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> Register(UserDTO user)
        {
            try
            {
                string passwordHash = BCrypt.HashPassword(user.Password);

                user.Role = Role.User;
                user.Password = passwordHash;

                await _userRepo.RegisterAsync(user);

                return Ok($"Successfully registered, you can now login.");
            }
            catch (Exception ex)
            {
                return StatusCode(403, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("assignrole")]
        [ProducesResponseType(200, Type = typeof(UserAuthDTO))]
        public async Task<IActionResult> AssignRoleAsync(UserRoleDTO userRole)
        {
            // This checks if the role provided is included in the Role Model by checking its properties
            PropertyInfo[] properties = typeof(Role).GetProperties(BindingFlags.Public | BindingFlags.Static);
            
            if (!properties.Any(method => method.Name == userRole.Role))
                return StatusCode(400, new { message = $"Invalid role: {userRole.Role}"});

            try
            {
            await _userRepo.AssignRoleAsync(userRole);
            return Ok($"Succesfully changed {userRole.Username}'s role to {userRole.Role}");
            }
            catch (Exception ex)
            {
                return StatusCode(403, new { message = ex.Message });
            }
        }
    }
}
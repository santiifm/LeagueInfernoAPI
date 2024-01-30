using System.Threading.Tasks;
using league_inferno_api.Data;
using league_inferno_api.DTOs;
using league_inferno_api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace league_inferno_api.Repository
{
    using BCrypt.Net;
    using league_inferno_api.Models;

    public class UsersRepository(AppDbContext context) : IUsersRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<UserDTO> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => username == u.Username);

            if (user == null)
            {
                // Throw a NotFoundException or a similar exception with a 404 status code
                throw new Exception($"User with username '{username}' not found");
            }
            
            return new UserDTO
            {
                Username = user.Username,
                Password = user.Password
            };
        }

        public async Task<UserDTO> RegisterAsync(string username, string password)
        {
            string passwordHash = BCrypt.HashPassword(password);

            var user = new User
            {
                Username = username,
                Password = passwordHash,
            };

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new Exception($"User with username '{user.Username}' already exists");
            }

            return new UserDTO
            {
                Username = user.Username,
                Password = user.Password
            };
        }
    }
}
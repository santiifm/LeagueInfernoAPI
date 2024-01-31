using league_inferno_api.Models;
using league_inferno_api.Data;
using league_inferno_api.DTOs;
using league_inferno_api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace league_inferno_api.Repository
{
    public class UsersRepository(AppDbContext context) : IUsersRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<User> AuthenticateAsync(string Username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == Username);

            if (user == null)
            {
                // Throw a NotFoundException or a similar exception with a 404 status code
                throw new Exception($"User with Username '{Username}' not found");
            }
            return user;
        }

        public async Task RegisterAsync(UserDTO user)
        {
            var newUser = new User
            {
                Username = user.Username,
                PasswordHash = user.Password,
                Role = Role.User
            };

            try
            {
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new Exception($"User with Username '{user.Username}' already exists");
            }
        }

        public async Task AssignRoleAsync(UserRoleDTO userRole)
        {
            if (!Enum.IsDefined(typeof(Role), userRole.Role))
            {
                throw new ArgumentException($"Invalid role: {userRole.Role}");
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userRole.Username);

            if (user == null)
            {
                throw new Exception($"User doesn't exist");
            }

            user.Role = userRole.Role;
            try 
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new Exception($"User with Username '{user.Username}' already exists");
            }
        }
    }
}
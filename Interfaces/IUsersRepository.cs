using league_inferno_api.DTOs;
using league_inferno_api.Models;

namespace league_inferno_api.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> AuthenticateAsync(string Username);
        Task RegisterAsync(UserDTO user);
        Task AssignRoleAsync(UserRoleDTO userRole);
    }
}
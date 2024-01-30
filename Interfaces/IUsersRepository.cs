using league_inferno_api.DTOs;

namespace league_inferno_api.Interfaces
{
    public interface IUsersRepository
    {
        Task<UserDTO> AuthenticateAsync(string username, string password);
        Task<UserDTO> RegisterAsync(string username, string password);
    }
}
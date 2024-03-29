using System.Threading.Tasks;
using league_inferno_api.Models;

namespace league_inferno_api.DTOs
{
    public class UserDTO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public string? Role { get; set; }
    }
}
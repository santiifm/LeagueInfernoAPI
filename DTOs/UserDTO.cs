using System.Threading.Tasks;

namespace league_inferno_api.DTOs
{
    public class UserDTO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
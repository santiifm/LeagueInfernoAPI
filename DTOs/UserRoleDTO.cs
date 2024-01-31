using System.Threading.Tasks;
using league_inferno_api.Models;

namespace league_inferno_api.DTOs
{
    public class UserRoleDTO
    {
        public required string Username { get; set; }
        public required string Role { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;

namespace league_inferno_api.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class User : BaseEntity
    {
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string Role { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
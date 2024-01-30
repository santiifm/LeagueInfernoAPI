using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace league_inferno_api.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class User : BaseEntity
    {
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Password { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
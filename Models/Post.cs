using System.Data;

namespace league_inferno_api.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ChampionId { get; set; }
        public Champion Champion { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
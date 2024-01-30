using System.Data;

namespace league_inferno_api.Models
{
    public class Post : BaseEntity
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required int ChampionId { get; set; }
        public required Champion Champion { get; set; }
        public required int UserId { get; set; }
        public required User User { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
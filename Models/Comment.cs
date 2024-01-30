namespace league_inferno_api.Models
{
    public class Comment : BaseEntity
    {
        public required string Content { get; set; }
        public required int UserId { get; set; }
        public required User User { get; set; }
        public required int PostId { get; set; }
        public required Post Post { get; set; }
        public int? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
        public int? ChampionId { get; set; }
        public Champion? Champion { get; set; }
    }
}
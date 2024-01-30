namespace league_inferno_api.Models
{
    public class Ability : BaseEntity
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }  
        public required int ChampionId { get; set; } 
        public required Champion Champion { get; set; }
    }
}
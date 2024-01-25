namespace league_inferno_api.Models
{
    public class Ability
    {
     public int Id { get; set; }
     public string Name { get; set; }
     public string Type { get; set; }
     public string Description { get; set; }  
     public int ChampionId { get; set; } 
     public Champion Champion { get; set; }
    }
}
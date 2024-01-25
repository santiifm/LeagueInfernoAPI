namespace league_inferno_api.Models{

    public class Champion {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Ability> Abilities { get; set; }
    }
}
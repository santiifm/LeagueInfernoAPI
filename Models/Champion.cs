namespace league_inferno_api.Models{

    public class Champion : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required ICollection<Ability> Abilities { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
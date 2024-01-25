namespace league_inferno_api.Models
{
    public class User
    {
     public int Id { get; set; }   
     public string Name { get; set; }
     public string Role { get; set; }
     public string Email { get; set; }
     public string PasswordHash { get; set; }
     public ICollection<Post> Posts { get; set; }
     public ICollection<Comment> Comments { get; set; }
    }
}
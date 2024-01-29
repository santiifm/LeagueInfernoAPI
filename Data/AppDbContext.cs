using league_inferno_api.Models;
using Microsoft.EntityFrameworkCore;

namespace league_inferno_api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Champion> Champions { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
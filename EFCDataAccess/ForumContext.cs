using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace EFCDataAccess;

public class ForumContext : DbContext
{
    public DbSet<Forum> Forums { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<SubForum> SubForums { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Forum.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Forum>().HasKey(forum => forum.Id);
        modelBuilder.Entity<Post>().HasKey(post => post.Id);
        modelBuilder.Entity<SubForum>().HasKey(subForum => subForum.Id);
        modelBuilder.Entity<User>().HasKey(user => user.Username);
    }

    public void SeedForum()
    {
        if (Forums.Any()) return;

        Forum[] forums =
        {
            new Forum(1, "Football", "Everything about football"),
            new Forum(2, "Basketball", "Everything about basketball")
        };
        
        Forums.AddRange(forums);
        SaveChanges();
    }

    public void SeedSubForum()
    {
        if (SubForums.Any()) return;

        SubForum[] subForums =
        {
            new SubForum(1, "Ronaldo", "Everything about ronaldo"),
            new SubForum(2, "Messi", "Everything about messi")
        };
        
        SubForums.AddRange(subForums);
        SaveChanges();
    }

    public void SeedPost()
    {
        if (Posts.Any()) return;

        Post[] posts =
        {
            new Post("Club", "Manchester United"),
            new Post("Club", "PSG")
        };

        Posts.AddRange(posts);
        SaveChanges();
    }

    public void SeedUser()
    {
        if (Users.Any()) return;

        User[] users =
        {
            new User("rodrigo", "rodrigo12345")
        };
        
        Users.AddRange(users);
        SaveChanges();
    }
}
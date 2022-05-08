using Entities;
using Microsoft.EntityFrameworkCore;

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
}
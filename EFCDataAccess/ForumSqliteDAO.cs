using Application;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess;

public class ForumSqliteDAO : IForumDAO
{
    private readonly ForumContext context;

    public ForumSqliteDAO(ForumContext context)
    {
        this.context = context;
    }

    public async Task<Forum> AddForumAsync(Forum newForumItem)
    {
        EntityEntry<Forum> added = await context.Forums.AddAsync(newForumItem);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<SubForum> AddSubForumAsync(SubForum newSubForumItem, int forumId)
    {
        Forum? forum = await context.Forums.FindAsync(forumId);
        
        if (forum is null) 
        {
            throw new Exception($"Cannot find the forum with the id: {forumId}");
        }
            
        EntityEntry<SubForum> added = await context.SubForums.AddAsync(newSubForumItem);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<Post> AddPostAsync(Post newPostItem, int forumId, int subForumId)
    {
        SubForum? subForum = await context.SubForums.FindAsync(subForumId);

        if (subForum is null) 
        {
            throw new Exception($"Cannot find the sub forum with id: {subForumId}");
        }

        subForum.Posts.Add(newPostItem);

        await context.SaveChangesAsync();
        return newPostItem;
    }

    public async Task<Forum> GetForumByIdAsync(int id)
    {
        Forum forum = context.Forums.Include(forum => forum.SubForums).ThenInclude(subForum => subForum.Posts).Include(forum1 => forum1.SubForums).First(forum => forum.Id == id);
        return forum;
    }

    public async Task<List<Forum>> GetAllForumsAsync()
    { 
        return await context.Forums.ToListAsync();
    }

    public async Task<SubForum?> GetSubForumAsync(int forumId, int subForumId)
    {
        SubForum subForum = await context.SubForums.Include(forum => forum.Posts).FirstAsync(forum => forum.Id == subForumId);
        return subForum;
    }

    public async Task<Post?> GetPostAsync(int forumId, int subForumId, int postId)
    {
        Post post = context.Posts.First(post => post.Id == postId);
        return post;
    }
}
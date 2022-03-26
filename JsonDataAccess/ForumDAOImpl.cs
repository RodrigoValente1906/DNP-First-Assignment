using Application;
using Entities;

namespace JsonDataAccess;

public class ForumDAOImpl : IForumDAO
{
    private JsonForumContext jsonForumContext;
    
    public ForumDAOImpl(JsonForumContext jsonForumContext) 
    {
        this.jsonForumContext = jsonForumContext;
    }
    
    public async Task<List<Forum>> GetAllForumsAsync() 
    {
        return jsonForumContext.Forums.ToList();
    }

    public async Task<SubForum?> GetSubForumAsync(int forumId, int subForumId) 
    {
        Forum forum = await GetForumByIdAsync(forumId);
        return forum.SubForums.First(subForum => subForum.Id == subForumId);
    }

    public async Task AddSubForumAsync(SubForum newSubForumItem, int forumId) 
    {
        Forum forumById = await GetForumByIdAsync(forumId);
        if (forumById.SubForums.Any()) 
        {
            int largestId = forumById.SubForums.Max(subForum => subForum.Id);
            newSubForumItem.Id = largestId + 1;
        }
        else 
        {
            newSubForumItem.Id = 1;
        }
        
        jsonForumContext.Forums.First(forum => forum.Id == forumId).SubForums.Add(newSubForumItem);
        await jsonForumContext.SaveChanges();
    }
    
    public async Task AddPostAsync(Post newPostItem, int forumId, int subForumId) 
    {
        SubForum? subForum = (await GetSubForumAsync(forumId, subForumId));
        if (subForum.Posts.Any()) 
        {
            int largestId = subForum.Posts.Max(post => post.Id);
            newPostItem.Id = largestId + 1;
        }
        else 
        {
            newPostItem.Id = 1;
        }
        
        jsonForumContext.Forums.First(forum => forum.Id == forumId).SubForums.First(subForum => subForum.Id == subForumId).Posts.Add(newPostItem);
        await jsonForumContext.SaveChanges();
    }
    
    public async Task<Post?> GetPostAsync(int forumId, int subForumId, int postId) 
    {
        Post? first = (await GetSubForumAsync(forumId, subForumId))?.Posts.First(post => post.Id == postId);
        jsonForumContext.Dispose();
        return first;
    }
    
    public async Task AddForumAsync(Forum newForumItem) 
    {
        if (jsonForumContext.Forums.Any()) 
        {
            int largestId = jsonForumContext.Forums.Max(forum => forum.Id);
            newForumItem.Id = largestId + 1;
        }
        else 
        {
            newForumItem.Id = 1;
        }

        jsonForumContext.Forums.Add(newForumItem);
        await jsonForumContext.SaveChanges();
    }

    public async Task<Forum> GetForumByIdAsync(int id) 
    {
        return jsonForumContext.Forums.First(forum => forum.Id == id);
    }
}
using Contracts;
using Entities;

namespace Application;

public class ForumServiceImpl : IForumService
{
    private IForumDAO forumDao;

    public ForumServiceImpl(IForumDAO forumDao) 
    {
        this.forumDao = forumDao;
    }
    
    public async Task AddForumAsync(Forum newForumItem)
    {
        await forumDao.AddForumAsync(newForumItem);
    }
    
    public async Task<Forum> GetForumByIdAsync(int id) 
    {
        return await forumDao.GetForumByIdAsync(id);
    }

    public async Task<List<Forum>> GetAllForumsAsync() 
    {
        return await forumDao.GetAllForumsAsync();
    }

    public async Task<SubForum?> GetSubForumAsync(int forumId, int subForumId)
    {
        return await forumDao.GetSubForumAsync(forumId, subForumId);
    }

    public async Task AddSubForumAsync(SubForum newSubForumItem, int forumId) 
    {
        await forumDao.AddSubForumAsync(newSubForumItem, forumId);
    }
    
    public async Task AddPostAsync(Post newPostItem, int forumId, int subForumId) 
    {
        await forumDao.AddPostAsync(newPostItem, forumId, subForumId);
    }
    
    public async Task<Post?> GetPostAsync(int forumId, int subForumId, int postId) 
    {
        return await forumDao.GetPostAsync(forumId, subForumId, postId);
    }
    
    

}
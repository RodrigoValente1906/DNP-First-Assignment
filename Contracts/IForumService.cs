using Entities;

namespace Contracts;

public interface IForumService
{
    public Task AddForumAsync(Forum newForumItem);
    public Task<Forum> GetForumByIdAsync(int id);
    public Task<List<Forum>> GetAllForumsAsync();
    public Task<SubForum?> GetSubForumAsync(int forumId, int subForumId);
    public Task AddSubForumAsync(SubForum newSubForumItem, int forumId);
    public Task AddPostAsync(Post newPostItem, int forumId, int subForumId);
    public Task<Post?> GetPostAsync(int forumId, int subForumId, int postId);
}
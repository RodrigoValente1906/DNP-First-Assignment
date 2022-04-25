using Entities;

namespace Contracts;

public interface IForumService
{
    public Task<Forum> AddForumAsync(Forum newForumItem);
    public Task<SubForum> AddSubForumAsync(SubForum newSubForumItem, int forumId);
    public Task<Post> AddPostAsync(Post newPostItem, int forumId, int subForumId);
    public Task<Forum> GetForumByIdAsync(int id);
    public Task<List<Forum>> GetAllForumsAsync();
    public Task<SubForum?> GetSubForumAsync(int forumId, int subForumId);
    public Task<Post?> GetPostAsync(int forumId, int subForumId, int postId);
}
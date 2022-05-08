using Application;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCDataAccess;

public class UserSqliteDAO : IUserDAO
{
    private readonly ForumContext forumContext;

    public UserSqliteDAO(ForumContext forumContext)
    {
        this.forumContext = forumContext;
    }

    public async Task<User> RegisterUserAsync(User user)
    {
        await forumContext.Users.AddAsync(user);
        await forumContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetUserAsync(string username)
    {
        User first =await forumContext.Users.FirstAsync(user => user.Username.Equals(username));
        return first;
    }

    public async Task<bool> IsUsernameTaken(string username)
    {
        bool boolean = forumContext.Users.Any(user => user.Username.Equals(username));
        return boolean;
    }
}
using Application;
using Entities;

namespace JsonDataAccess;

public class UserDAOImpl : IUserDAO
{
    private JsonUserContext jsonUserContext;

    public UserDAOImpl(JsonUserContext jsonUserContext) 
    {
        this.jsonUserContext = jsonUserContext;
    }

    public async Task RegisterUserAsync(User user) 
    {
        jsonUserContext.Users.Add(user);
        await jsonUserContext.SaveChanges();
    }

    public Task<User> GetUserAsync(string username) 
    {
        List<User> users = jsonUserContext.Users.ToList();
        User? find= users.Find(user => user.Username.Equals(username));
        return Task.FromResult(find);
    }
    
    public async Task<bool> IsUsernameTaken(string username) 
    {
        ICollection<User> allUsers = jsonUserContext.Users;
        return allUsers.Any(user => user.Username.Equals(username));
    }
}
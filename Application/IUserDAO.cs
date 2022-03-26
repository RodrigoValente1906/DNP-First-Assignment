using Entities;

namespace Application;

public interface IUserDAO
{
    public Task RegisterUserAsync(User user);
    public Task<bool> IsUsernameTaken(string username);
    public Task<User> GetUserAsync(string username);
}
using Entities;

namespace Application;

public interface IUserDAO
{
    public Task RegisterUserAsync(User user);
    public Task<User> GetUserAsync(string username);
    public Task<bool> IsUsernameTaken(string username);
}
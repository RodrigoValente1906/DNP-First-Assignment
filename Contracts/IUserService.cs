using Entities;

namespace Contracts;

public interface IUserService
{
    public Task<User> RegisterUserAsync(string username, string password);
    public Task<User> GetUserAsync(string username);
}
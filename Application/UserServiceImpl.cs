using Contracts;
using Entities;

namespace Application;

public class UserServiceImpl : IUserService
{
    private readonly IUserDAO userDao;
    
    public UserServiceImpl(IUserDAO userDao) 
    {
        this.userDao = userDao;
    }
    
    public async Task<User> RegisterUserAsync(string username, string password) 
    {
        ValidateUsername(username);
        ValidatePassword(password);

        if (await userDao.IsUsernameTaken(username)) 
        {
            throw new Exception($"Username, {username} already taken. Please choose another one");
        }
        await userDao.RegisterUserAsync(new User(username, password));
        return new User(username, password);
    }
    
    public async Task<User> GetUserAsync(string username) 
    {
        User? find = await userDao.GetUserAsync(username);
        return find;
    }
    
    private void ValidatePassword(string password) 
    {
        if (string.IsNullOrEmpty(password)) 
        {
            throw new Exception("Password cannot be empty");
        }

        if (password.Length <= 5) 
        {
            throw new Exception("Password must be greater than five characters");
        }

        int count = 0;
        foreach (char c in password) 
        {
            if (Char.IsNumber(c)) 
            {
                count++;
                break;
            }
        }

        if (count == 0) 
        {
            throw new Exception("Password must have at least one digit");
        }
    }
    
    private void ValidateUsername(string username) 
    {
        if (string.IsNullOrEmpty(username)) 
        {
            throw new Exception("Username cannot be empty");
        }
    }
    
}
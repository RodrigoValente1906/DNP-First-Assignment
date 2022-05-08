using System.ComponentModel.DataAnnotations;

namespace Entities;

public class User
{
    [Key]
    public string Username { get; set; }
    public string Password { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public User()
    {
    }
}

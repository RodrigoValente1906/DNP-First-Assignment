using System.Text.Json;
using Entities;

namespace JsonDataAccess;

public class JsonUserContext
{
    private string userPath = "users.json";
    private ICollection<User>? users;

    public JsonUserContext() 
    {
        if (File.Exists(userPath)) 
        {
            LoadData();
        }
        else 
        {
            CreateFile();
        }
    }
    
    public ICollection<User> Users 
    {
        get 
        {
            if (users==null) 
            {
                LoadData();
            }

            return users!; 
        }
    }
    
    private void LoadData() 
    {
        string usersAsJson = File.ReadAllText(userPath);
        users = JsonSerializer.Deserialize<List<User>>(usersAsJson);
    }

    private async void CreateFile() 
    {
        users = new List<User>();
        await SaveChanges();
    }

    public async Task SaveChanges() 
    {
        string userAsJson = JsonSerializer.Serialize(users, new JsonSerializerOptions 
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = false
        });
        await File.WriteAllTextAsync(userPath, userAsJson);
        users = null;
    }
}
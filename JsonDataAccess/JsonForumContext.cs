using System.Text.Json;
using Entities;

namespace JsonDataAccess;

public class JsonForumContext : IDisposable
{
    private string forumPath = "forums.json";
    private ICollection<Forum>? forums;
    
    public JsonForumContext() 
    {
        if (File.Exists(forumPath)) 
        {
            LoadData();
        }
        else 
        {
            CreateFile();
        }
    }

    public ICollection<Forum> Forums 
    {
        get 
        {
            if (forums==null) 
            {
                LoadData();
            }

            return forums;
        }
    }
    
    private async void CreateFile() 
    {
        forums = new List<Forum>();
        await SaveChanges();
    }

    public async Task SaveChanges() 
    {
        string forumAsJson = JsonSerializer.Serialize(forums, new JsonSerializerOptions 
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = false

        });
        await File.WriteAllTextAsync(forumPath, forumAsJson);
        forums = null;
    }

    private void LoadData() 
    {
        string forumAsJson = File.ReadAllText(forumPath);
        forums = JsonSerializer.Deserialize<List<Forum>>(forumAsJson);
    }

    public void Dispose() 
    {
        forums = null;
    }
}
using System.Text;
using System.Text.Json;
using Contracts;
using Entities;

namespace RESTClient;

public class UserHttpService : IUserService
{
    public async Task<User> RegisterUserAsync(string username, string password)
    {
        using HttpClient client = new();

        string todoAsJson = JsonSerializer.Serialize(username);

        StringContent content = new(todoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("https://localhost:7079/User", content);
        string responseContent = await response.Content.ReadAsStringAsync();
    
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {responseContent}");
        }
    
        User returned = JsonSerializer.Deserialize<User>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    
        return returned;
    }

    public async Task<User> GetUserAsync(string username)
    {
        using HttpClient client = new ();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7079/User/{username}");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        User returnedUser = JsonSerializer.Deserialize<User>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return returnedUser;
    }
}
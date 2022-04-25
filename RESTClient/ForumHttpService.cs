using System.Text;
using System.Text.Json;
using Contracts;
using Entities;

namespace RESTClient;

public class ForumHttpService : IForumService
{
    public async Task<Forum> AddForumAsync(Forum newForumItem)
    {
        using HttpClient client = new();

        string forumAsJson = JsonSerializer.Serialize(newForumItem);

        StringContent content = new(forumAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync($"https://localhost:7079/", content);
        string responseContent = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {responseContent}");
        }
       
        Forum returned = JsonSerializer.Deserialize<Forum>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return returned;
    }

    public async Task<SubForum> AddSubForumAsync(SubForum newSubForumItem, int forumId)
    {
        using HttpClient client = new();

        string forumAsJson = JsonSerializer.Serialize(newSubForumItem);

        StringContent content = new(forumAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync($"https://localhost:7079/{forumId}", content);
        string responseContent = await response.Content.ReadAsStringAsync();
    
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {responseContent}");
        }
    
        SubForum returned = JsonSerializer.Deserialize<SubForum>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    
        return returned;
    }

    public async Task<Post> AddPostAsync(Post newPostItem, int forumId, int subForumId)
    {
        using HttpClient client = new();

        string forumAsJson = JsonSerializer.Serialize(newPostItem);

        StringContent content = new(forumAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync($"https://localhost:7079/{forumId}/{subForumId}", content);
        string responseContent = await response.Content.ReadAsStringAsync();
    
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {responseContent}");
        }
    
        Post returned = JsonSerializer.Deserialize<Post>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    
        return returned;
    }

    public async Task<Forum> GetForumByIdAsync(int id)
    {
        using HttpClient client = new ();
                 
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7079/{id}");
        
        string content = await response.Content.ReadAsStringAsync();
        
       
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }

        Forum forums = JsonSerializer.Deserialize<Forum>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        
        return forums;
    }

    public async Task<List<Forum>> GetAllForumsAsync()
    {
        using HttpClient client = new ();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7079/Forum");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
       
        List<Forum> forums = JsonSerializer.Deserialize<List<Forum>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    
        return forums;
    }

    public async Task<SubForum?> GetSubForumAsync(int forumId, int subForumId)
    {
        using HttpClient client = new ();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7079/{forumId}/{subForumId}");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
       
        SubForum subForums = JsonSerializer.Deserialize<SubForum>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    
        return subForums;
    }

    public async Task<Post?> GetPostAsync(int forumId, int subForumId, int postId)
    {
        using HttpClient client = new ();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7079/{forumId}/{subForumId}/{postId}");
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode}, {content}");
        }
       
        Post post = JsonSerializer.Deserialize<Post>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    
        return post;
    }
}
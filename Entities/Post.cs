using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Post
{
    [Key]
    public int Id { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }

    public Post(string header, string body)
    {
        Header = header;
        Body = body;
    }

    public Post()
    {
        
    }
}
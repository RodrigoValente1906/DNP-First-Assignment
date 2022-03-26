namespace Entities;

public class Post
{
    public int Id { get; set; }
    public string Owner { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }

    public Post(string owner, string header, string body)
    {
        Owner = owner;
        Header = header;
        Body = body;
    }

    public Post()
    {
        
    }
}
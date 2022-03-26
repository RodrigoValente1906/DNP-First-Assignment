namespace Entities;

public class SubForum
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Id { get; set; }
    public ICollection<Post> Posts { get; set; }
    
    public SubForum() 
    {
        Posts = new List<Post>();
    }
    
}
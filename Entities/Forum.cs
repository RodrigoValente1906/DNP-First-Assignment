using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Forum
{
    public string ForumName { get; set; }
    public string ForumDescription { get; set; }
    [Key]
    public int Id { get; set; }
    public ICollection<SubForum> SubForums { get; set; }

    public Forum() 
    {
        SubForums = new List<SubForum>();
    }
}
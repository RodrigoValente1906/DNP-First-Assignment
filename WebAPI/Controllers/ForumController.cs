using Application;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ForumController : ControllerBase
{
    private IForumDAO forumDao;

    public ForumController(IForumDAO forumDao)
    {
        this.forumDao = forumDao;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Forum>>> GetAll()
    {
        try
        {
            ICollection<Forum> forums = await forumDao.GetAllForumsAsync();
            return Ok(forums);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<SubForum>> AddSubForum([FromBody] SubForum newSubForum, int forumId)
    {
        try
        {
            SubForum added = await forumDao.AddSubForumAsync(newSubForum, forumId);
            return Created($"/forums/{added.Id}", added);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<SubForum>> GetSubForum([FromBody] int forumId, int subForumId)
    {
        try
        {
            SubForum subForum = await forumDao.GetSubForumAsync(forumId, subForumId);
            return Ok(subForum);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
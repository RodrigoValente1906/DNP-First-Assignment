using Application;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class UserController : ControllerBase
{
    private IUserDAO userDao;

    public UserController(IUserDAO userDao)
    {
        this.userDao = userDao;
    }
    
    [HttpPost]
    public async Task<ActionResult<User>> AddUserAsync([FromBody] User user)
    {
        try
        {
            User userAdded =  await userDao.RegisterUserAsync(user);
            return Ok(userAdded);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("{username}")]
    public async Task<ActionResult<User>> GetUserAsync([FromRoute] string username)
    {
        try
        {
            User user = await userDao.GetUserAsync(username);
            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

}
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;
namespace FlexForm_Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController
{   
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
    
}
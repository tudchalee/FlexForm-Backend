using FlexForm_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FlexForm_Backend.Authorization;
using FlexForm_Backend.Helper;
using FlexForm_Backend.Models;

namespace FlexForm_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserService _userService;

    public UserController(
        IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
    
    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);
        return Ok(response);
    }
    
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest model)
    {
        _userService.Register(model);
        return Ok(new { message = "Registration successful" });
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _userService.Delete(id);
        return Ok(new { message = "User deleted successfully" });
    }
}
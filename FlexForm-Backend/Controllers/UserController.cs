using FlexForm_Backend.Models;
using FlexForm_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace FlexForm_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserService _userService;
    private IMapper _mapper;

    public UserController(
        IUserService userService,IMapper _mapper)
    {
        _userService = userService;
        _mapper = this._mapper;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest model)
    {
        _userService.Register(model);
        return Ok(new {message = "Registration Successful"});
    }
}
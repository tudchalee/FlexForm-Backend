namespace FlexForm_Backend.Services;

using FlexForm_Backend.Entities;
using FlexForm_Backend.Models;
using FlexForm_Backend.Helper;
using FlexForm_Backend.Authorization;
using BCrypt.Net;
using AutoMapper;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<Users> GetAll();
    Users GetById(string id);
    void Register(RegisterRequest model);
    void Delete(string id);
}

public class UserService : IUserService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;
    private IUserService _userServiceImplementation;

    public UserService(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }
    
    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _context.user.SingleOrDefault(x => x.username == model.Username);

        // validate
        if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
            throw new AppException("Username or password is incorrect");

        // authentication successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = _jwtUtils.GenerateToken(user);
        return response;
    }
    public void Register(RegisterRequest model)
    {
        // validate
        if (_context.user.Any(x => x.username == model.username))
            throw new AppException("Username '" + model.username + "' is already taken");

        // map model to new user object
        var user = _mapper.Map<Users>(model);

        // hash password
        user.PasswordHash = BCrypt.HashPassword(model.password);

        // save user
        _context.user.Add(user);
        _context.SaveChanges();
    }
    
    public void Delete(string id)
    {
        var user = GetUser(id);
        _context.user.Remove(user);
        _context.SaveChanges();
    }
    
    public IEnumerable<Users> GetAll()
    {
        return _context.user;
    }

    public Users GetById(string id)
    {
        return GetUser(id);
    }
    
    private Users GetUser(string id)
    {
        var user = _context.user.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}
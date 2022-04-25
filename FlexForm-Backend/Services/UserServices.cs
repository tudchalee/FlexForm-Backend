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
    IEnumerable<User> GetAll();
    User GetById(string id);
    void Register(RegisterRequest model);
    void Delete(string id);
    void Update(string id, UpdateRequest model);
}

public class UserServices : IUserService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;
    private IUserService _userServiceImplementation;

    public UserServices(
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
        var user = _context.user.SingleOrDefault(x => x.username == model.username);

        // validate
        if (user == null || !BCrypt.Verify(model.password, user.password))
            throw new AppException("Username or password is incorrect");
        
        // authentication successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = _jwtUtils.GenerateToken(user);
        return response;
    }
    
    public void Delete(string id)
    {
        var user = GetById(id);
        _context.user.Remove(user);
        _context.SaveChanges();
    }
    
    public IEnumerable<User> GetAll()
    {
        return _context.user;
    }

    public User GetById(string id)
     {
         var user = _context.user.Find(id);
         if (user == null) throw new KeyNotFoundException("User not Found");
         return user;
     }

    public void Register(RegisterRequest model)
    {
        // Generate employeeid
        Guid generateId = Guid.NewGuid();
        Console.WriteLine(generateId);
        // string employee_id == model.employee_id;
        if (_context.user.Any(x => x.username == model.username))
            throw new ApplicationException("'Username '" + model.username + "'is already taken");
        
        var passwordHash = BCrypt.HashPassword(model.password);
        model.password = passwordHash;
        
        var user = _mapper.Map<User>(model);
        user.employee_id = generateId;
        
        _context.user.Add(user);
        _context.SaveChanges();
    }

    public void Update(string id, UpdateRequest model)
    {
        var user = GetById(id);

        // validate
        if (model.username != user.username && _context.user.Any(x => x.username == model.username))
            throw new AppException("Username '" + model.username + "' is already taken");

        // hash password if it was entered
        if (!string.IsNullOrEmpty(model.password))
        {
            var passwordHash = BCrypt.HashPassword(model.password);
            model.password = passwordHash;
        }

        if (user.username != null)
        {
            user.email = model.email;
        }

        // copy model to user and save
        _mapper.Map(model, user);
        _context.user.Update(user);
        _context.SaveChanges();
    }
}
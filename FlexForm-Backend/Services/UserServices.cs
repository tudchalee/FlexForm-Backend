
namespace FlexForm_Backend.Services;
using FlexForm_Backend.Models;
using FlexForm_Backend.Helper;
using AutoMapper;
using BCrypt.Net;
using FlexForm_Backend.Entities;

public interface IUserService
{
    IEnumerable<User> GetAll();
    User GetById(string id);
    void Register(RegisterRequest model);
}
public class UserServices : IUserService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public UserServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public IEnumerable<User> GetAll()
    {
        return _context.user;
    }

    public User GetById(string id)
     {
         var user = _context.user.Find(id);
         Console.WriteLine(user);
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
}
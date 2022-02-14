using System.Diagnostics;

namespace FlexForm_Backend.Services;
using FlexForm_Backend.Models;
using Microsoft.EntityFrameworkCore;
using FlexForm_Backend.Helper;

public interface IUserService
{
    IEnumerable<User> GetAll();
    //User GetById(string id);
}
public class UserServices : IUserService
{
    private DataContext _context;

    public UserServices(DataContext context)
    {
        _context = context;
    }
    public IEnumerable<User> GetAll()
    {
        return _context.user;
    }

    /* public User GetById(string id)
     {
        return getUser(id);
     }
  
     private User getUser(string id)
     {
        var user = _context.Users.Find((id));
        if (user == null) throw new KeyNotFoundException("User not Found");
        return user;
     }*/
}
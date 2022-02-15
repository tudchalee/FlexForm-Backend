using FlexForm_Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace FlexForm_Backend.Helper;
using FlexForm_Backend.Entities;
public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server database
        options.UseNpgsql("Host=localhost;Database=flexform;Username=postgres;Password=FreyaFlexForm_2564");
    }

    public DbSet <User> user { get; set; }
}
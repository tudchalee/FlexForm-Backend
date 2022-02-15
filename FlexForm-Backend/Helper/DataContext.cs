namespace FlexForm_Backend.Helper;

using FlexForm_Backend.Entities;
using Microsoft.EntityFrameworkCore;

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

    public DbSet <Users> user { get; set; }
}
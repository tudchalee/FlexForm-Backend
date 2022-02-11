using FlexForm_Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlexForm_Backend.Helper;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;
    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)         
    { options.UseNpgsql("Host=freya.postgres.database.azure.com;Database=flexform;Username=freya;Password=FreyaFlexForm_2564");              
       // options.UseCamelCaseNamingConvention();         
    } 
    public DbSet<User> user { get; set; }
}
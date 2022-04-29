global using FlexForm_Backend.Services;
global using Microsoft.EntityFrameworkCore;
using FlexForm_Backend.Authorization;
using FlexForm_Backend.Helper;
using FlexForm_Backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IUserService, UserServices>();
builder.Services.AddSingleton<FlexformDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<FlexformDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("FlexformDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IFlexformService, FlexformServices>();
builder.Services.AddScoped<IFormInputService, FormInputServices>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IJwtUtils,JwtUtils>();
// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<FlexformDatabaseSettings>(builder.Configuration.GetSection("FlexformDatabaseSettings"));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();

app.UseCors();

app.Run("http://localhost:4000");
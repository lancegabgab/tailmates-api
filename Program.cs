using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using TailMates.Data;
using TailMates.Models;
using TailMates.Services;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

builder.Services.AddDbContext<TailmatesContext>(options =>
    options.UseSqlServer(
        Environment.GetEnvironmentVariable("DB_CONNECTION")
        //builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services
    .AddIdentityCore<User>()
    .AddEntityFrameworkStores<TailmatesContext>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
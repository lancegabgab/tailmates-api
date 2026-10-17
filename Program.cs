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

builder.Services.AddScoped<AuthService>();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AngularPolicy", policy =>
	{
		policy
			.WithOrigins(
				"http://localhost:4200",
				"https://tailmates-kappa.vercel.app"
			)
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("AngularPolicy");

app.MapControllers();

app.Run();
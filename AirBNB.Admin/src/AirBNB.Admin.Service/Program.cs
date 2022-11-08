using System.Text;
using AirBNB.Admin.Service.Data;
using AirBNB.Admin.Service.Helpers;
using AirBNB.Admin.Service.Interfaces;
using AirBNB.Admin.Service.Middlewares;
using AirBNB.Admin.Service.Repositories;
using AirBNB.Admin.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
builder.Services.AddDbContext<DataContext>(
           dbContextOptions => dbContextOptions
               .UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion)
               // The following three options help with debugging, but should
               // be changed or removed for production.
               .LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors()
       );

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<UserService, UserService>();

builder.Services.AddScoped<PasswordHelpers, PasswordHelpers>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
      {
          appBuilder.UseMiddleware<VerifySuperAdmin>();
      });

app.MapControllers();

app.Run();

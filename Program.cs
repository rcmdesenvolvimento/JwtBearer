using JwtBearer.Models;
using JwtBearer.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<TokenService>();

var app = builder.Build();

var _user = new User(1, "teste@gmail.com", "123", new[]
{
    "student", "premium"
});

app.MapGet("/", (TokenService service) => service.Generate(_user));

app.Run();

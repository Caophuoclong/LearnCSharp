using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using aspcore.Data;
using aspcore.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("db1");
builder.Services.AddDbContext<MovieContext>(options => options.UseSqlServer(connectionString));
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

app.MapGet("/", () => "Hello World!");

app.Run();

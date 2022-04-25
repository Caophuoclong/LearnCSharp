using Microsoft.EntityFrameworkCore;
using mobilestore.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("db1");
builder.Services.AddDbContext<MobileStoreContext>(optinos =>
{
    optinos.UseSqlServer(connectionString);
});
builder.Services.AddRazorPages();
builder.Services.Configure<RouteOptions>(routeOptions =>
{
    routeOptions.LowercaseUrls = true;
});

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoint =>
{
    endpoint.MapRazorPages();
    endpoint.MapGet("/{*action}", async (context) =>
    {
        Console.WriteLine(context.Request.Headers.ContentType);
        Console.WriteLine($"{context.GetRouteValue("action")}");


        await context.Response.WriteAsync("<h1>Xin chao</h1>");
    });
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Erorr");
});

app.Run();

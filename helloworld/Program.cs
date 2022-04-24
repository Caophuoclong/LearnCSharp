using Microsoft.Extensions.Options;
using helloworld.Middleware;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<SecondMiddleware>();
builder.Services.AddOptions();
builder.Services.Configure<TestOptions>(builder.Configuration.GetSection(TestOptions.Name));
var app = builder.Build();
app.UseStaticFiles();

app.UseManyMiddlewares();
app.UseRouting();
app.UseEndpoints(enpoint =>
{
    enpoint.MapGet("/", async (context) =>
    {
        await context.Response.WriteAsync("\nHelloworld");
    });
});

// app.MapGet("/", async (context) =>
// {
//     Console.WriteLine($"in chao");

//     var options = context.RequestServices.GetService<IOptions<TestOptions>>().Value;
//     await context.Response.WriteAsync(options.level);
//     await context.Response.WriteAsync("\nHelloworld");
// });
// app.MapPost("/", () => "Hello World!");
app.Run(async context =>
{
    // context.Response.StatusCode = StatusCodes.Status404NotFound;
    await context.Response.WriteAsync("Page not found");
});
app.Run();

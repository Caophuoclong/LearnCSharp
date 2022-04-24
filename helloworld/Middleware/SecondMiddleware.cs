namespace helloworld.Middleware
{
    public class SecondMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.Headers.Add("Second", "Hi xin chao");
            // await context.Response.WriteAsync("This is secondMiddleware");
            Console.WriteLine($"xinchao");

            await next(context);
        }
    }
}
namespace helloworld.Middleware
{
    public static class UseMiddleware
    {
        public static void UseManyMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<FirstMiddleware>();
            app.UseMiddleware<SecondMiddleware>();
        }

    }
}
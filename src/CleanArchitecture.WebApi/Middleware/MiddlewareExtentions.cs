namespace CleanArchitecture.WebApi.Middleware;

public static class MiddlewareExtentions
{
    public static IApplicationBuilder UseMiddlewareExtensions(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        return app;
    }
}

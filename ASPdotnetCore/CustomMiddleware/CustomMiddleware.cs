using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    [System.Obsolete]
    public async Task InvokeAsync(HttpContext context, IHostingEnvironment env)
    {
        string filePath = Path.Combine(env.WebRootPath, $"data/data.txt");
        var file = System.IO.File.Create(filePath);
        var writer = new System.IO.StreamWriter(file);

        writer.WriteLine(context.Request);

        var scheme = context.Request.Scheme;
        writer.WriteLine($"Request scheme: [{scheme}]");

        var host = context.Request.Host;
        writer.WriteLine($"Request host: [{host}]");

        var path = context.Request.Path;
        writer.WriteLine($"Request path: [{path}]");

        var query = context.Request.QueryString;
        writer.WriteLine($"Request queryString: [{query}]");

        var requestBody = await new System.IO.StreamReader(context.Request.Body).ReadToEndAsync();
        writer.WriteLine($"Request body: [{requestBody}]");

        writer.Dispose();

        await _next(context);
    }
}

public static class RequestCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }


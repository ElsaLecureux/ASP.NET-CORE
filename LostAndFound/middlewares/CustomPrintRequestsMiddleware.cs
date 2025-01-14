using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class CustomPrintRequestMiddleware {

    private readonly RequestDelegate _next;

    public CustomPrintRequestMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context){
        Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
        await _next(context);
        Console.WriteLine($"Response status code value: {context.Response.StatusCode}");
    }
}

public static class CustomPrintRequestMiddlewareExtensions {
    public static IApplicationBuilder UseCustomPrintRequestMiddleware(this IApplicationBuilder builder){
        return builder.UseMiddleware<CustomPrintRequestMiddleware>();
    }
}
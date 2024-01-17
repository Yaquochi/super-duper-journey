using LearningPlatform.API.Contracts;
using System.Net;

namespace LearningPlatform.API.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var errorResponse = new ErrorResponse((int)HttpStatusCode.InternalServerError, ex.Message);

            await context.Response.WriteAsJsonAsync(errorResponse);

            context.Response.ContentType = "application/json";
        }
    }
}
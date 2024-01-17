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
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var errorResponse = new ErrorResponse((int)HttpStatusCode.InternalServerError, ex.Message);

			context.Response.ContentType = "application/json";

			await context.Response.WriteAsJsonAsync(errorResponse);
		}
	}
}
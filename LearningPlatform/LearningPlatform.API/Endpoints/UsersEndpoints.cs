using LearningPlatform.API.Contracts.Users;
using LearningPlatform.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.API.Endpoints;

public static class UsersEndpoints
{
	public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapPost("register", Register);

		app.MapPost("login", Login);

		return app;
    }

	private static async Task<IResult> Register(
		[FromBody] RegisterUserRequest request,
		UserService usersService)
	{
		await usersService.Register(request.UserName, request.Email, request.Password);

		return Results.Ok();
	}

	private static async Task<IResult> Login(
		[FromBody] LoginUserRequest request,
		UserService usersService,
		HttpContext context)
	{
		var token = await usersService.Login(request.Email, request.Password);

		context.Response.Cookies.Append("secretCookie", token);

		return Results.Ok(token);
	}
}
using LearningPlatform.API.Contracts.Users;
using LearningPlatform.Application.Services;
using LearningPlatform.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.API.Endpoints;

public static class UsersEndpoints
{
	public static void MapUsersEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapPost("register", Register);

		app.MapPost("login", Login);
	}

	private static async Task<IResult> Register(
		[FromBody] RegisterUserRequest request,
		UserService userService)
	{
		var hashedPassword = PasswordHasher.Generate(request.Password);

		var user = User.Create(
			Guid.NewGuid(),
			request.UserName,
			hashedPassword,
			request.Email);

		await userService.CreateUser(user);

		return Results.Ok(user); 
	}

	private static async Task<IResult> Login(
		[FromBody] LoginUserRequest request,
		UserService userService)
	{
		var user = await userService.GetByEmail(request.Email);

		var result = PasswordHasher.Verify(request.Password, user.PasswordHash);

		return result ? Results.Ok() : Results.BadRequest();
	}
}
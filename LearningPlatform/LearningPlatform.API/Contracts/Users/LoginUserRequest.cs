using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.API.Contracts.Users;

public record LoginUserRequest(
	[Required] string Email,
	[Required] string Password);
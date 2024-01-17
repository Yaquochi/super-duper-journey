namespace LearningPlatform.API.Contracts.Courses;

public record GetCourseResponse(
	Guid Id,
	string Title,
	string Description,
	decimal Price);

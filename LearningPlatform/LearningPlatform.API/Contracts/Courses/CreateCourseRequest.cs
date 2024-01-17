using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.API.Contracts.Courses;

public record CreateCourseRequest(
	[Required] string Title,
	[Required] string Description,
	[Required] decimal Price);
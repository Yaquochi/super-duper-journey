using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.API.Contracts.Courses;

public record UpdateCourseRequest(
	[Required] string Title,
	[Required] string Description,
	[Required] decimal Price);
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.API.Contracts.Lessons;

public record UpdateLessonRequest(
	[Required] string Title,
	[Required] string Description,
	[Required] string VideoLink,
	[Required] string LessonText);
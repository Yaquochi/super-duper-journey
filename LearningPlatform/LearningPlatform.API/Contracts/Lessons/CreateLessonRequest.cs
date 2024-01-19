using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.API.Contracts.Lessons;

public record CreateLessonRequest(
	[Required] string Title,
	[Required] string Description,
	[Required] string VideoLink,
	[Required] string LessonText
	);
using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.API.Contracts.Lessons;

public record GetLessonsResponse(
	Guid Id,
	Guid CourseId,
	string Title,
	string Description,
	string VideoLink,
	string LessonText);
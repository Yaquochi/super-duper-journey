using LearningPlatform.API.Contracts.Lessons;
using LearningPlatform.Core.Models;
using LearningPlatforn.Application.Services;

namespace LearningPlatform.API.Endpoints;

public static class LessonsEndpoints
{
	public static void MapLessonsEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapPost("lessons/{courseId:guid}", CreateLesson);

		app.MapGet("lessons/{courseId:guid}", GetLessons);
	}

	private static async Task<IResult> CreateLesson(
		[AsParameters] Guid courseId,
		[AsParameters] CreateLessonRequest request,
		LessonsService lessonsService)
	{
		var lesson = new Lesson(
			Guid.NewGuid(),
			courseId,
			request.Title,
			request.Description,
			request.VideoLink,
			request.LessonText);

		await lessonsService.CreateLesson(lesson);

		return Results.Ok();
	}

	private static async Task<IResult> GetLessons(
		[AsParameters] Guid courseId,
		LessonsService lessonsService)
	{
		var lessons = await lessonsService.GetLessons(courseId);

		var response = lessons
			.Select(l => new GetLessonsResponse(l.Id, l.CourseId, l.Title, l.Description, l.VideoLink, l.LessonText));

		return Results.Ok(response);
	}
}
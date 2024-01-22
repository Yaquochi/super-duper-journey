using LearningPlatform.API.Contracts.Lessons;
using LearningPlatform.Core.Models;
using LearningPlatforn.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.API.Endpoints;

public static class LessonsEndpoints
{
	public static void MapLessonsEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapPost("lessons/{courseId:guid}", CreateLesson);

		app.MapGet("lessons/course/{courseId:guid}", GetLessons);

		app.MapGet("lessons/{id:guid}", GetLessonById);

		app.MapPut("lessons/{id:guid}", UpdateLesson);

		app.MapDelete("lessons/{id:guid}", DeleteLesson);
	}

	private static async Task<IResult> CreateLesson(
		[FromRoute] Guid courseId,
		[FromBody] CreateLessonRequest request,
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
		[FromRoute] Guid courseId,
		LessonsService lessonsService)
	{
		var lessons = await lessonsService.GetLessons(courseId);

		var response = lessons
			.Select(l => new GetLessonsResponse(l.Id, l.CourseId, l.Title, l.Description, l.VideoLink, l.LessonText));

		return Results.Ok(response);
	}

	private static async Task<IResult> GetLessonById(
		[FromRoute] Guid id,
		LessonsService lessonsService)
	{
		var lesson = await lessonsService.GetLessonById(id);

		var response = new GetLessonsResponse(id, lesson.CourseId, lesson.Title, lesson.Description, lesson.VideoLink, lesson.LessonText);

		return Results.Ok(response);
	}

	private static async Task<IResult> UpdateLesson(
		[FromRoute] Guid id,
		[FromBody] UpdateLessonRequest request,
		LessonsService lessonsService)
	{
		await lessonsService.UpdateLesson(
			id,
			request.Title,
			request.Description,
			request.VideoLink,
			request.LessonText);

		return Results.Ok();
	}

	private static async Task<IResult> DeleteLesson(
		[FromRoute] Guid id,
		LessonsService lessonsSerice)
	{
		await lessonsSerice.DeleteLesson(id);

		return Results.Ok();
	}
}
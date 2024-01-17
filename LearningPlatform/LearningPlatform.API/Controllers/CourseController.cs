using LearningPlatform.API.Contracts.Courses;
using LearningPlatform.Core.Models;
using LearningPlatforn.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CoursesController : ControllerBase
{
	private readonly CoursesService _courseService;

	public CoursesController(CoursesService coursesService)
	{
		_courseService = coursesService;
	}

	[HttpGet]
	public async Task<ActionResult> GetCourses()
	{
		var courses = await _courseService.GetCourses();

		var response = courses
			.Select(c => new GetCourseResponse(c.Id, c.Title, c.Description, c.Price));

		return Ok(response);
	}

	[HttpGet("{id:guid}")]
	public async Task<ActionResult> GetCourseById(Guid id)
	{
		var course = await _courseService.GetCourseById(id);

		var response = new GetCourseResponse(course.Id, course.Title, course.Description, course.Price);

		return Ok(response);
	}

	[HttpPost]
	public async Task CreateCourse(CreateCourseRequest request)
	{
		var course = new Course(Guid.NewGuid(),
			request.Title,
			request.Description,
			request.Price);

		await _courseService.CreateCourse(course);
	}

	[HttpDelete]
	public async Task DeleteCourse(Guid id)
	{
		await _courseService.DeleteCourse(id);
	}

	[HttpPut("{id:guid}")]
	public async Task UpdateCourse(Guid id, [FromBody] UpdateCourseRequest request)
	{
		await _courseService.UpdateCourse(id, request.Title, request.Description, request.Price);
	}
}
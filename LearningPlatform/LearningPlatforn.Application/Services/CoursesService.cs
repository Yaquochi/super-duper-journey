using LearningPlatform.Core.Models;
using LearningPlatform.DataAccess.Postgres.Repositories;

namespace LearningPlatforn.Application.Services;

public class CoursesService
{
	private readonly CourseRepository _courseRepository;

	public CoursesService(CourseRepository courseRepository)
	{
		_courseRepository = courseRepository;
	}

	public async Task CreateCourse(Course course)
	{
		await _courseRepository.Create(course);
	}

	public async Task<List<Course>> GetCourses()
	{
		return await _courseRepository.Get();
	}

	public async Task<Course> GetCourseById(Guid id)
	{
		return await _courseRepository.GetById(id);
	}

	public async Task UpdateCourse(
		Guid id,
		string title,
		string description,
		decimal price)
	{
		await _courseRepository.Update(id, title, description, price);
	}

	public async Task DeleteCourse(Guid id)
	{
		await _courseRepository.Delete(id);
	}
}
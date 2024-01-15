using LearningPlatform.Core.Models;
using LearningPlatform.DataAccess.Postgres.Repositories;

namespace LearningPlatforn.Application.Services
{
	public class CoursesService
	{
		private readonly CourseRepository _courseRepository;
		public CoursesService(CourseRepository courseRepository)
		{
			_courseRepository = courseRepository;
		}

		public async Task<List<Course>> GetCoursesAsync()
		{
			var entityCourses = await _courseRepository.Get();

			var courses = entityCourses
				.Select(e => new Course(e.Id, e.Title, e.Description, e.Price))
				.ToList();

			return courses;
		}
	}
}
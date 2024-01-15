using LearningPlatform.DataAccess.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DataAccess.Postgres.Repositories
{
	public class CourseRepository
	{
		private readonly LearningDbContext _context;

		public CourseRepository(LearningDbContext context)
		{
			_context = context;
		}

		public async Task<List<CourseEntity>> Get()
		{
			return await _context.Courses
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task Create(CourseEntity course)
		{
			var courseEntity = new CourseEntity()
			{
				Id = course.Id,
				Title = course.Title,
				Description = course.Description,
				Price = course.Price
			};

			await _context.Courses.AddAsync(courseEntity);
		    await _context.SaveChangesAsync();
		}
	}
}

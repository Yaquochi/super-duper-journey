using LearningPlatform.DataAccess.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DataAccess.Postgres.Repositories
{
	public class LessonsRepository
	{
		private LearningDbContext _context;

		public LessonsRepository(LearningDbContext context)
		{
			_context = context;
		}

		public async Task<List<LessonEntity>> Get()
		{
			return await _context.Lessons.ToListAsync();
		}

		public async Task Add(LessonEntity lesson)
		{
			await _context.Lessons.AddAsync(lesson);
			await _context.SaveChangesAsync();
		}
	}
}

using LearningPlatform.Core.Models;
using LearningPlatform.DataAccess.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DataAccess.Postgres.Repositories;

public class LessonsRepository
{
	private LearningDbContext _context;

	public LessonsRepository(LearningDbContext context)
	{
		_context = context;
	}

	public async Task Create(Lesson lesson)
	{
		var lessonEntity = new LessonEntity()
		{
			Id = lesson.Id,
			CourseId = lesson.CourseId,
			Title = lesson.Title,
			Description = lesson.Description,
			VideoLink = lesson.VideoLink,
			LessonText = lesson.LessonText
		};

		await _context.Lessons.AddAsync(lessonEntity);
		await _context.SaveChangesAsync();
	}

	public async Task<List<Lesson>> Get(Guid courseId)
	{
		return await _context.Lessons
			.Where(l => l.CourseId == courseId)
			.Select(l => new Lesson(l.Id, l.CourseId, l.Title, l.Description, l.VideoLink, l.LessonText))
			.ToListAsync();
	}

	public async Task<Lesson> GetById(Guid id)
	{
		var lessonEntity = await _context.Lessons
			.AsNoTracking()
			.FirstOrDefaultAsync(l => l.Id == id) ?? throw new Exception();

		var lesson = new Lesson(
			id,
			lessonEntity.CourseId,
			lessonEntity.Title,
			lessonEntity.Description,
			lessonEntity.VideoLink,
			lessonEntity.LessonText);

		return lesson;
	}

	public async Task Update(
		Guid id,
		string title,
		string description,
		string videoLink,
		string lessonText)
	{
		await _context.Lessons
			.Where(l => l.Id == id)
			.ExecuteUpdateAsync(s => s
			.SetProperty(l => l.Title, title)
			.SetProperty(l =>l.Description, description)
			.SetProperty(l => l.VideoLink, videoLink)
			.SetProperty(l => l.LessonText, lessonText));
	}

	public async Task Delete(Guid id)
	{
		await _context.Lessons
			.Where(l => l.Id == id)
			.ExecuteDeleteAsync();
	}
}
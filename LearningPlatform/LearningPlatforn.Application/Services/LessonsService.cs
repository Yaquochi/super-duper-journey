using LearningPlatform.Core.Models;
using LearningPlatform.DataAccess.Postgres.Repositories;

namespace LearningPlatforn.Application.Services;

public class LessonsService
{
	public readonly LessonsRepository _lessonsRepository;

	public LessonsService(LessonsRepository lessonsRepository)
	{
		_lessonsRepository = lessonsRepository;
	}

	public async Task CreateLesson(Lesson lesson)
	{
		await _lessonsRepository.Create(lesson);
	}

	public async Task<List<Lesson>> GetLessons(Guid courseId)
	{
		return await _lessonsRepository.Get(courseId);
	}
}

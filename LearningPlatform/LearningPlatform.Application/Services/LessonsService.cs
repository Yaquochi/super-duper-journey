using LearningPlatform.Application.Interfaces.Repositories;
using LearningPlatform.Core.Models;

namespace LearningPlatform.Application.Services;

public class LessonsService
{
    public readonly ILessonsRepository _lessonsRepository;

    public LessonsService(ILessonsRepository lessonsRepository)
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

    public async Task<Lesson> GetLessonById(Guid id)
    {
        return await _lessonsRepository.GetById(id);
    }

    public async Task UpdateLesson(
        Guid id,
        string title,
        string description,
        string videoLink,
        string lessonText)
    {
        await _lessonsRepository.Update(id, title, description, videoLink, lessonText);
    }

    public async Task DeleteLesson(Guid id)
    {
        await _lessonsRepository.Delete(id);
    }
}
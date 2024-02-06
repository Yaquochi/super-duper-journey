using LearningPlatform.Core.Models;

namespace LearningPlatform.Application.Interfaces.Repositories;
public interface ILessonsRepository
{
    Task Create(Lesson lesson);
    Task Delete(Guid id);
    Task<List<Lesson>> Get(Guid courseId);
    Task<Lesson> GetById(Guid id);
    Task Update(Guid id, string title, string description, string videoLink, string lessonText);
}
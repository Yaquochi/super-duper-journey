using LearningPlatform.Core.Models;

namespace LearningPlatform.Application.Interfaces;
public interface ICourseRepository
{
    Task Create(Course course);
    Task Delete(Guid id);
    Task<List<Course>> Get();
    Task<Course> GetById(Guid id);
    Task Update(Guid id, string title, string description, decimal price);
}
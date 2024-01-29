using LearningPlatform.Core.Models;

namespace LearningPlatform.Application.Interfaces;
public interface IUsersRepository
{
    Task Create(User user);
    Task<User> GetByEmail(string email);
}
using LearningPlatform.Application.Interfaces;
using LearningPlatform.Core.Models;

namespace LearningPlatform.Application.Services;
public class UserService
{
    private readonly IUsersRepository _usersRepository;

    public UserService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task CreateUser(User user)
    {
        await _usersRepository.Create(user);
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _usersRepository.GetByEmail(email);
    }
}
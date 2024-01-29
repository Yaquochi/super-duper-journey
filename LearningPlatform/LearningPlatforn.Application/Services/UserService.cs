using LearningPlatform.Core.Models;
using LearningPlatform.Persistance.Repositories;

namespace LearningPlatforn.Application.Services;
public class UserService
{
	private readonly UsersRepository _usersRepository;

    public UserService(UsersRepository usersRepository)
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
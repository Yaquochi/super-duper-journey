using LearningPlatform.Core.Models;

namespace LearningPlatform.Application.Interfaces.Auth;
public interface IJwtProvider
{
    string Generate(User user);
}
namespace LearningPlatform.Application.Interfaces.Auth;

public interface IPasswordHasher
{
    string Generate(string password);
    bool Verify(string password, string hashedPassword);
}
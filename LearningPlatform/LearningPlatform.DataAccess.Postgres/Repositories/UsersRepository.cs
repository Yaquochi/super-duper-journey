using AutoMapper;
using LearningPlatform.Core.Models;
using LearningPlatform.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistance.Repositories;
public class UsersRepository
{
	private readonly LearningDbContext _context;
	private readonly IMapper _mapper;

	public UsersRepository(LearningDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	public async Task Create(User user)
	{
		var userEntity = new UserEntity()
		{
			Id = user.Id,
			UserName = user.UserName,
			PasswordHash = user.PasswordHash,
			Email = user.Email
		};

		await _context.Users.AddAsync(userEntity);
		await _context.SaveChangesAsync();
	}

	public async Task<User> GetByEmail(string email)
	{
		var userEntity = await _context.Users
			.AsNoTracking()
			.FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

		return _mapper.Map<User>(userEntity);
	}
}
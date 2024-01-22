using LearningPlatform.Core.Models;
using LearningPlatform.DataAccess.Postgres.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DataAccess.Postgres.Repositories;

public class CourseRepository
{
	private readonly LearningDbContext _context;

	public CourseRepository(LearningDbContext context)
	{
		_context = context;
	}

	public async Task Create(Course course)
	{
		var courseEntity = new CourseEntity()
		{
			Id = course.Id,
			Title = course.Title,
			Description = course.Description,
			Price = course.Price
		};

		await _context.Courses.AddAsync(courseEntity);
		await _context.SaveChangesAsync();
	}

	public async Task<List<Course>> Get()
	{
		return await _context.Courses
			.ProjectToType<Course>()
			.ToListAsync();
	}

	public async Task<Course> GetById(Guid id)
	{
		var courseEntity = await _context.Courses
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception();

		var course = new Course(id, courseEntity.Title, courseEntity.Description, courseEntity.Price);

		return course;
	}

	public async Task Update(Guid id, string title, string description, decimal price)
	{
		await _context.Courses
			.Where(c => c.Id == id)
			.ExecuteUpdateAsync(s => s
				.SetProperty(c => c.Title, title)
				.SetProperty(c => c.Description, description)
				.SetProperty(c => c.Price, price));
	}

	public async Task Delete(Guid id)
	{
		await _context.Courses
			.Where(c => c.Id == id)
			.ExecuteDeleteAsync();
	}
}
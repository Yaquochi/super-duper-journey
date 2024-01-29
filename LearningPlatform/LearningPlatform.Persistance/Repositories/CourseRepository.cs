using AutoMapper;
using LearningPlatform.Application.Interfaces;
using LearningPlatform.Core.Models;
using LearningPlatform.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistance.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly LearningDbContext _context;
    private readonly IMapper _mapper;

    public CourseRepository(LearningDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
        var courseEntities = await _context.Courses
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<List<Course>>(courseEntities);
    }

    public async Task<Course> GetById(Guid id)
    {
        var courseEntity = await _context.Courses
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception();

        return _mapper.Map<Course>(courseEntity);
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
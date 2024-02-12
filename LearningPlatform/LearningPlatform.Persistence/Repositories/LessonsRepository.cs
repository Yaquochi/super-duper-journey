using AutoMapper;
using LearningPlatform.Application.Interfaces.Repositories;
using LearningPlatform.Core.Models;
using LearningPlatform.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistence.Repositories;

public class LessonsRepository : ILessonsRepository
{
    private readonly LearningDbContext _context;
    private readonly IMapper _mapper;

    public LessonsRepository(LearningDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Create(Lesson lesson)
    {
        var lessonEntity = new LessonEntity()
        {
            Id = lesson.Id,
            CourseId = lesson.CourseId,
            Title = lesson.Title,
            Description = lesson.Description,
            VideoLink = lesson.VideoLink,
            LessonText = lesson.LessonText
        };

        await _context.Lessons.AddAsync(lessonEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Lesson>> Get(Guid courseId)
    {
        var lessonEntity = await _context.Lessons
            .AsNoTracking()
            .Where(l => l.CourseId == courseId)
            .ToListAsync();

        return _mapper.Map<List<Lesson>>(lessonEntity);
    }

    public async Task<Lesson> GetById(Guid id)
    {
        var lessonEntity = await _context.Lessons
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Id == id) ?? throw new Exception();

        return _mapper.Map<Lesson>(lessonEntity);
    }

    public async Task Update(
        Guid id,
        string title,
        string description,
        string videoLink,
        string lessonText)
    {
        await _context.Lessons
            .Where(l => l.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(l => l.Title, title)
            .SetProperty(l => l.Description, description)
            .SetProperty(l => l.VideoLink, videoLink)
            .SetProperty(l => l.LessonText, lessonText));
    }

    public async Task Delete(Guid id)
    {
        await _context.Lessons
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync();
    }
}
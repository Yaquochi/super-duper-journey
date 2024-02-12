using AutoMapper;
using LearningPlatform.Core.Models;
using LearningPlatform.Persistence.Entities;

namespace LearningPlatform.Persistence;
public class DataBaseMappings : Profile
{
    public DataBaseMappings()
    {
        CreateMap<CourseEntity, Course>();
        CreateMap<LessonEntity, Lesson>();
        CreateMap<UserEntity, User>();
    }
}
using AutoMapper;
using LearningPlatform.Core.Models;
using LearningPlatform.DataAccess.Postgres.Entities;

namespace LearningPlatform.DataAccess.Postgres;
public class DataBaseMappings : Profile
{
    public DataBaseMappings()
    {
        CreateMap<CourseEntity, Course>();
        CreateMap<UserEntity, User>();
    }
}
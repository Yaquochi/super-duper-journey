using AutoMapper;
using LearningPlatform.Core.Models;
using LearningPlatform.Persistance.Entities;

namespace LearningPlatform.Persistance;
public class DataBaseMappings : Profile
{
	public DataBaseMappings()
	{
		CreateMap<CourseEntity, Course>();
		CreateMap<LessonEntity, Lesson>();
		CreateMap<UserEntity, User>();
	}
}
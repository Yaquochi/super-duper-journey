using LearningPlatform.Persistance.Configurations;
using LearningPlatform.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistance;

public class LearningDbContext(DbContextOptions<LearningDbContext> options)
	: DbContext(options)
{
	public DbSet<CourseEntity> Courses { get; set; }

	public DbSet<LessonEntity> Lessons { get; set; }

	public DbSet<UserEntity> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new CourseConfiguration());
		modelBuilder.ApplyConfiguration(new LessonConfiguration());
	}
}
using LearningPlatform.DataAccess.Postgres.Configurations;
using LearningPlatform.DataAccess.Postgres.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DataAccess.Postgres;

public class LearningDbContext(DbContextOptions<LearningDbContext> options)
	: DbContext(options)
{
	public DbSet<CourseEntity> Courses { get; set; }

	public DbSet<LessonEntity> Lessons { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new CourseConfiguration());
		modelBuilder.ApplyConfiguration(new LessonConfiguration());
	}
}
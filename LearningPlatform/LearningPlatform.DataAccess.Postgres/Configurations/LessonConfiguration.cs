using LearningPlatform.DataAccess.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LearningPlatform.DataAccess.Postgres.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<LessonEntity>
{
	public void Configure(EntityTypeBuilder<LessonEntity> builder)
	{
		builder.HasKey(c => c.Id);

		builder.HasOne(l => l.Course)
			.WithMany(c => c.Lessons);
	}
}

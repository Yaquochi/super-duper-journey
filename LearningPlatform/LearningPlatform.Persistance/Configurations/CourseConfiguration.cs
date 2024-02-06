using LearningPlatform.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LearningPlatform.Persistance.Configurations;

public partial class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
{
	public void Configure(EntityTypeBuilder<CourseEntity> builder)
	{
		builder.HasKey(c => c.Id);

		builder.HasMany(c => c.Lessons)
			.WithOne(l => l.Course)
			.HasForeignKey(l => l.CourseId);
	}
}

namespace LearningPlatform.DataAccess.Postgres.Entities;

public class LessonEntity
{
	public Guid Id { get; set; }

	public Guid CourseId { get; set; }

	public CourseEntity? Course { get; set; }

	public string LessonText { get; set; } = string.Empty;

	public string Title { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public string VideoLink { get; set; } = string.Empty;
} 
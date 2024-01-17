namespace LearningPlatform.Core.Models;

public class Lesson
{
	public Lesson(Guid id, string title, string description, string videlink, string lessontext)
	{
		Id = id;
		Title = title;
		Description = description;
		VideoLink = videlink;
		LessonText = lessontext;
	}

	public Guid Id { get; set; }

	public Guid CourseId { get; set; }

	public string Title { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public string VideoLink { get; set; } = string.Empty;

	public string LessonText { get; set; } = string.Empty;
}
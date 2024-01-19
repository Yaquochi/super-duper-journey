namespace LearningPlatform.Core.Models;

public class Lesson
{
	public Lesson(Guid id, Guid courseId, string title, string description, string videoLink, string lessonText)
	{
		Id = id;

		CourseId = courseId;

		Title = !string.IsNullOrEmpty(title) ? title 
			: throw new ArgumentException("Title cannot be null!");

		Description = !string.IsNullOrEmpty(description) ? description 
			: throw new ArgumentException("Description cannot be null!");

		VideoLink = !string.IsNullOrEmpty(videoLink) ? videoLink
			: throw new ArgumentException("VideoLink cannot be null!");

		LessonText = !string.IsNullOrEmpty(lessonText) ? lessonText
			: throw new ArgumentException("LessonText cannot be null!");
	}

	public Guid Id { get; private set; }

	public Guid CourseId { get; private set; }

	public string Title { get; private set; } = string.Empty;

	public string Description { get; private set; } = string.Empty;

	public string VideoLink { get; private set; } = string.Empty;

	public string LessonText { get; private set; } = string.Empty;
}
namespace LearningPlatform.Core.Models;

public class Course
{
	public Course(Guid id, string title, string description, decimal price)
	{
		Id = id;
		Title = title;
		Description = description;
		Price = price;
	}

	public Guid Id { get; set; }

	public string Title { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public decimal Price { get; set; } = 0;

	public List<Lesson>? Lessons { get; set; } = [];
}
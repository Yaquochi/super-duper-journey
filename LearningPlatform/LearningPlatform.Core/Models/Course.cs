namespace LearningPlatform.Core.Models;

public class Course
{
	private readonly List<Lesson> _lessons = [];

	private Course(Guid id, string title, string description, decimal price)
	{
		Id = id;
		Title = title;
		Description = description;
		Price = price;
	}

	public Guid Id { get; private set; }

	public string Title { get; private set; } = string.Empty;

	public string Description { get; private set; } = string.Empty;

	public decimal Price { get; private set; } = 0;

	public IReadOnlyList<Lesson>? Lessons => _lessons;

	public static Course Create(Guid id, string title, string description, decimal price)
	{
		if (string.IsNullOrEmpty(title)) throw new ArgumentException("Title cannot be null!");

		if (string.IsNullOrEmpty(description)) throw new ArgumentException("Description cannot be null!");

		if (price < 0) throw new ArgumentException("Price cannot be null!");

		return new Course(id, title, description, price);
	}
}
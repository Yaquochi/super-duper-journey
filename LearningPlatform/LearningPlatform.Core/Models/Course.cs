namespace LearningPlatform.Core.Models;

public class Course
{
	private readonly List<Lesson> _lessons = [];

    public Course() { }

    public Course(Guid id, string title, string description, decimal price)
	{
		Id = id;

		Title = !string.IsNullOrEmpty(title) ? title 
			: throw new ArgumentException("Title cannot be null!");

		Description = !string.IsNullOrEmpty(description) ? description 
			: throw new ArgumentException("Description cannot be null!");

		Price = price > 0 ? price
			: throw new ArgumentException("Price cannot be null!");
	}

	public Guid Id { get; private set; }

	public string Title { get; private set; } = string.Empty;

	public string Description { get; private set; } = string.Empty;

	public decimal Price { get; private set; } = 0;

	public IReadOnlyList<Lesson>? Lessons => _lessons;
}
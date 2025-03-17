namespace DevHobby.CourseFlow.Domain.Entities;

public class Category
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Course>? Courses { get; set; } = new List<Course>();
}

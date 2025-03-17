namespace DevHobby.CourseFlow.Application.Features.Courses.Queries.GetCourseDetail;

public class CourseDetailVm
{
    public Guid CourseId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime PublicationDate { get; set; }
    public Guid CategoryId { get; set; }
    public CategoryDto Category { get; set; } = default!;
}
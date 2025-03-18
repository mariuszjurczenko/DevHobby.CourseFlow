namespace DevHobby.CourseFlow.Application.Features.Categories.Queries.GetCategoriesListWithCourses;

public class CategoryCourseDto
{
    public Guid CourseId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string Author { get; set; } = string.Empty;
    public DateTime PublicationDate { get; set; }
    public Guid CategoryId { get; set; }
}

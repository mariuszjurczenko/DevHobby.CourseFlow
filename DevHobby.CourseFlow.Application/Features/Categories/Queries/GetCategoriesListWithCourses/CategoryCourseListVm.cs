namespace DevHobby.CourseFlow.Application.Features.Categories.Queries.GetCategoriesListWithCourses;

public class CategoryCourseListVm
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<CategoryCourseDto> Courses { get; set; } = new List<CategoryCourseDto>();
}

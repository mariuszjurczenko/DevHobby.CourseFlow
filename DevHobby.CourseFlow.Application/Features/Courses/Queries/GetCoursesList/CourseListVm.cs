namespace DevHobby.CourseFlow.Application.Features.Courses.Queries.GetCoursesList;

public class CourseListVm
{
    public Guid CourseId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime PublicationDate { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}
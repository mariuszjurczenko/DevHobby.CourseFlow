namespace DevHobby.CourseFlow.Application.Features.Courses.Queries.GetCoursesExport;

public class CourseExportDto
{
    public Guid CourseId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime PublicationDate { get; set; }
}

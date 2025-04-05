namespace DevHobby.CourseFlow.Application.Features.Courses.Queries.GetCoursesExport;

public class CourseExportFileVm
{
    public string CourseExportFileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public byte[]? Data { get; set; }
}
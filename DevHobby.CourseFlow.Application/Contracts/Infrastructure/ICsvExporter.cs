using DevHobby.CourseFlow.Application.Features.Courses.Queries.GetCoursesExport;

namespace DevHobby.CourseFlow.Application.Contracts.Infrastructure;

public interface ICsvExporter
{
    byte[] ExportCoursesToCsv(List<CourseExportDto> courseExportDtos);
}

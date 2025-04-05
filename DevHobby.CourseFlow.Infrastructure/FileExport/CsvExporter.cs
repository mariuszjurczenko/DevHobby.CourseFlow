using CsvHelper;
using DevHobby.CourseFlow.Application.Contracts.Infrastructure;
using DevHobby.CourseFlow.Application.Features.Courses.Queries.GetCoursesExport;

namespace DevHobby.CourseFlow.Infrastructure.FileExport;

public class CsvExporter : ICsvExporter
{
    public byte[] ExportCoursesToCsv(List<CourseExportDto> courseExportDtos)
    {
        using var memoryStream = new MemoryStream();

        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter);
            csvWriter.WriteRecords(courseExportDtos);
        }

        return memoryStream.ToArray();
    }
}

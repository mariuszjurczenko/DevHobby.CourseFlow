using AutoMapper;
using DevHobby.CourseFlow.Application.Contracts.Infrastructure;
using DevHobby.CourseFlow.Application.Contracts.Persistence;
using DevHobby.CourseFlow.Domain.Entities;
using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Courses.Queries.GetCoursesExport;

public class GetCoursesExportQueryHandler : IRequestHandler<GetCoursesExportQuery, CourseExportFileVm>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Course> _courseRepository;
    private readonly ICsvExporter _csvExporter;

    public GetCoursesExportQueryHandler(IMapper mapper,
        IAsyncRepository<Course> courseRepository,
        ICsvExporter csvExporter)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
        _csvExporter = csvExporter;
    }

    public async Task<CourseExportFileVm> Handle(GetCoursesExportQuery request, CancellationToken cancellationToken)
    {
        var allCourses = _mapper.Map<List<CourseExportDto>>((await _courseRepository.ListAllAsync()).OrderBy(x => x.PublicationDate));

        var fileData = _csvExporter.ExportCoursesToCsv(allCourses);

        var coursrExportFileDto = new CourseExportFileVm()
        {
            ContentType = "text/csv",
            Data = fileData,
            CourseExportFileName = $"{Guid.NewGuid()}.csv"
        };

        return coursrExportFileDto;
    }
}

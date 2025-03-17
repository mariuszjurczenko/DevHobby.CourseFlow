using AutoMapper;
using DevHobby.CourseFlow.Application.Contracts.Persistence;
using DevHobby.CourseFlow.Domain.Entities;
using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Courses;

public class GetCoursesListQueryHandler : IRequestHandler<GetCoursesListQuery, List<CourseListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Course> _asyncRepository;

    public GetCoursesListQueryHandler(IMapper mapper, IAsyncRepository<Course> asyncRepository)
    {
        _mapper = mapper;
        _asyncRepository = asyncRepository;
    }

    public async Task<List<CourseListVm>> Handle(GetCoursesListQuery request, CancellationToken cancellationToken)
    {
        var allCourses = (await _asyncRepository.ListAllAsync()).OrderBy(x => x.PublicationDate);

        return _mapper.Map<List<CourseListVm>>(allCourses);
    }
}

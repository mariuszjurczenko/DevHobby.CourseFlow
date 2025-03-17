using AutoMapper;
using DevHobby.CourseFlow.Application.Contracts.Persistence;
using DevHobby.CourseFlow.Domain.Entities;
using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Courses.Queries.GetCourseDetail;

public class GetCourseDetailQueryHandler : IRequestHandler<GetCourseDetailQuery, CourseDetailVm>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Course> _courseRepository;
    private readonly IAsyncRepository<Category> _categoryRepository;

    public GetCourseDetailQueryHandler(
        IMapper mapper,
        IAsyncRepository<Course> courseRepository,
        IAsyncRepository<Category> categoryRepository)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<CourseDetailVm> Handle(GetCourseDetailQuery request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdAsync(request.Id);

        var courseDetailDto = _mapper.Map<CourseDetailVm>(course);

        var category = await _categoryRepository.GetByIdAsync(course.CategoryId);

        courseDetailDto.Category = _mapper.Map<CategoryDto>(category);

        return courseDetailDto;
    }
}

using AutoMapper;
using DevHobby.CourseFlow.Application.Contracts.Persistence;
using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Categories.Queries.GetCategoriesListWithCourses;

public class GetCategoriesListWithCoursesQueryHandler : IRequestHandler<GetCategoriesListWithCoursesQuery, List<CategoryCourseListVm>>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesListWithCoursesQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryCourseListVm>> Handle(GetCategoriesListWithCoursesQuery request, CancellationToken cancellationToken)
    {
        var list = await _categoryRepository.GetCategoriesWithCourses(request.IncludePlannedCourses);

        return _mapper.Map<List<CategoryCourseListVm>>(list);
    }
}

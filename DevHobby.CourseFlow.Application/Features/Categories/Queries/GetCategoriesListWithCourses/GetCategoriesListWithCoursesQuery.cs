using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Categories.Queries.GetCategoriesListWithCourses;

public class GetCategoriesListWithCoursesQuery : IRequest<List<CategoryCourseListVm>>
{
    public bool IncludePlannedCourses { get; set; }
}

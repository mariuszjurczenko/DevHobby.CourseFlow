using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Courses;

public class GetCoursesListQuery : IRequest<List<CourseListVm>>
{
}

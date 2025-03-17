using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Courses.Queries.GetCoursesList;

public class GetCoursesListQuery : IRequest<List<CourseListVm>>
{
}

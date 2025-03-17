using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Courses;

public class GetCourseDetailQuery : IRequest<CourseDetailVm>
{
    public Guid Id { get; set; }
}

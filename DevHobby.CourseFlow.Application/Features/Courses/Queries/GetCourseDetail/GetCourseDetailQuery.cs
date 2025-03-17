using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Courses.Queries.GetCourseDetail;

public class GetCourseDetailQuery : IRequest<CourseDetailVm>
{
    public Guid Id { get; set; }
}

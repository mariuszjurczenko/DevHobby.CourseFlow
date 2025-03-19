using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseCommand : IRequest
{
    public Guid CourseId { get; set; }
}

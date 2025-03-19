using DevHobby.CourseFlow.Application.Contracts.Persistence;
using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
{
    private readonly ICourseRepository _courseRepository;

    public DeleteCourseCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var courseToDelete = await _courseRepository.GetByIdAsync(request.CourseId);

        await _courseRepository.DeleteAsync(courseToDelete);
    }
}

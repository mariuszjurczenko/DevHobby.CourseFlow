using AutoMapper;
using DevHobby.CourseFlow.Application.Contracts.Persistence;
using DevHobby.CourseFlow.Domain.Entities;
using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
{
    private readonly IMapper _mapper;
    private readonly ICourseRepository _courseRepository;

    public UpdateCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
    }

    public async Task Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var courseToUpdate = await _courseRepository.GetByIdAsync(request.CourseId);

        _mapper.Map(request, courseToUpdate, typeof(UpdateCourseCommand), typeof(Course));

        await _courseRepository.UpdateAsync(courseToUpdate);
    }
}

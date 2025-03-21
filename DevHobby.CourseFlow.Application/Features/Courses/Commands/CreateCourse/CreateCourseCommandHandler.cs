using AutoMapper;
using DevHobby.CourseFlow.Application.Contracts.Persistence;
using DevHobby.CourseFlow.Domain.Entities;
using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly ICourseRepository _courseRepository;

    public CreateCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
    }

    public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCourseCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        var course = _mapper.Map<Course>(request);

        course = await _courseRepository.AddAsync(course);

        return course.CourseId;
    }
}

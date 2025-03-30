using AutoMapper;
using DevHobby.CourseFlow.Application.Contracts.Infrastructure;
using DevHobby.CourseFlow.Application.Contracts.Persistence;
using DevHobby.CourseFlow.Application.Exceptions;
using DevHobby.CourseFlow.Application.Models;
using DevHobby.CourseFlow.Domain.Entities;
using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly ICourseRepository _courseRepository;
    private readonly IEmailService _emailService;

    public CreateCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository, IEmailService emailService)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
        _emailService = emailService;
    }

    public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCourseCommandValidator(_courseRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        var course = _mapper.Map<Course>(request);

        course = await _courseRepository.AddAsync(course);

        var email = new Email()
        {
            To = "mariusz@dev-hobby.pl",
            Body = $"A new course was created: {request}",
            Subject = "A new course was created"
        };

        try
        {
            await _emailService.SendEmailAsync(email);
        }
        catch (Exception)
        {
            // dodamy tutaj logowanie
        }

        return course.CourseId;
    }
}

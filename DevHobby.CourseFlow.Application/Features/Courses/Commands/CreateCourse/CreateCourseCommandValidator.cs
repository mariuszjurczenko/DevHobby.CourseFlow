using DevHobby.CourseFlow.Application.Contracts.Persistence;
using FluentValidation;

namespace DevHobby.CourseFlow.Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    private readonly ICourseRepository _courseRepository;

    public CreateCourseCommandValidator(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        RuleFor(p => p.PublicationDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(DateTime.Now);
        RuleFor(e => e)
            .MustAsync(CourseNameAndDateUnique)
            .WithMessage("An course with the same name and date already exists.");

    }

    private async Task<bool> CourseNameAndDateUnique(CreateCourseCommand command, CancellationToken token)
    {
        return await _courseRepository.IsCourseNameAndDateUnique(command.Name, command.PublicationDate);
    }
}

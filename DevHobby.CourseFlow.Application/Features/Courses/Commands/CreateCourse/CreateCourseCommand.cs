using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime PublicationDate { get; set; }
    public Guid CategoryId { get; set; }

    public override string ToString()
    {
        return $"Course name: {Name}; Price: {Price}; By: {Author}; On: {PublicationDate.ToShortDateString()}; Description: {Description}";
    }
}

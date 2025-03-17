using DevHobby.CourseFlow.Domain.Entities;

namespace DevHobby.CourseFlow.Application.Contracts.Persistence;

public interface ICourseRepository : IAsyncRepository<Course>
{
}

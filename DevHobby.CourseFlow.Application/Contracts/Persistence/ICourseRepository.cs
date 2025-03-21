using DevHobby.CourseFlow.Domain.Entities;

namespace DevHobby.CourseFlow.Application.Contracts.Persistence;

public interface ICourseRepository : IAsyncRepository<Course>
{
    Task<bool> IsCourseNameAndDateUnique(string name, DateTime publicationDate);
}

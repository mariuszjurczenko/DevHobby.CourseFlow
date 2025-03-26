using DevHobby.CourseFlow.Application.Contracts.Persistence;
using DevHobby.CourseFlow.Domain.Entities;

namespace DevHobby.CourseFlow.Persistence.Repositories;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(DevHobbyDbContext dbContext) : base(dbContext)
    {       
    }

    public Task<bool> IsCourseNameAndDateUnique(string name, DateTime publicationDate)
    {
        var matches = _dbContext.Courses.Any(c => c.Name.Equals(name) && c.PublicationDate.Date.Equals(publicationDate));
        return Task.FromResult(matches);
    }
}

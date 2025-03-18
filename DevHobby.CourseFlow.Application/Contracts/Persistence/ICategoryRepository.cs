using DevHobby.CourseFlow.Domain.Entities;

namespace DevHobby.CourseFlow.Application.Contracts.Persistence;

public interface ICategoryRepository : IAsyncRepository<Category>
{
    Task<List<Category>> GetCategoriesWithCourses(bool includePlannedCourses);
}

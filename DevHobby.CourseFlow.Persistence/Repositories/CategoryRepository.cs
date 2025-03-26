using DevHobby.CourseFlow.Application.Contracts.Persistence;
using DevHobby.CourseFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevHobby.CourseFlow.Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DevHobbyDbContext dbContext) : base(dbContext)
    {       
    }

    public async Task<List<Category>> GetCategoriesWithCourses(bool includePlannedCourses)
    {
        var allCategories = await _dbContext.Categories.Include(c => c.Courses).ToListAsync();

        if (!includePlannedCourses)
        {
            allCategories.ForEach(c => c.Courses.ToList().RemoveAll(c => c.PublicationDate > DateTime.Today));
        }

        return allCategories;
    }
}

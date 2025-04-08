using DevHobby.CourseFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevHobby.CourseFlow.Persistence.IntegrationTests;

public abstract class TestBase
{
    protected DbContextOptions<DevHobbyDbContext> GetDbContextOptions()
    {
        return new DbContextOptionsBuilder<DevHobbyDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase_" + Guid.NewGuid().ToString()).Options;
    }

    protected async Task SeedBasicData(DevHobbyDbContext context)
    {
        var categoryId = Guid.Parse("{f7aac0ff-28f0-4427-be8b-41472b9b55db}");

        context.Categories.Add(new Category
        {
            CategoryId = categoryId,
            Name = "Test Category"
        });

        await context.SaveChangesAsync();
    }

    protected async Task<Guid> SeedTestCourse(DevHobbyDbContext context, string name = "Test Course", int price = 100)
    {
        var courseId = Guid.NewGuid();
        var categoryId = Guid.Parse("{f7aac0ff-28f0-4427-be8b-41472b9b55db}");

        // Sprawdzamy czy kategoria już istnieje
        var categoryExists = await context.Categories.AnyAsync(c => c.CategoryId == categoryId);

        if (!categoryExists)
        {
            await SeedBasicData(context);
        }

        context.Courses.Add(new Course
        {
            CourseId = courseId,
            Name = name,
            Price = price,
            Author = "Test Author",
            CategoryId = categoryId,
            Description = "Test Description",
            PublicationDate = DateTime.Now
        });

        await context.SaveChangesAsync();
        return courseId;
    }
}

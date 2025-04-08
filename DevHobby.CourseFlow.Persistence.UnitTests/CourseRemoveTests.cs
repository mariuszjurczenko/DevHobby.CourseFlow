using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace DevHobby.CourseFlow.Persistence.IntegrationTests;

public class CourseRemoveTests : TestBase
{
    private readonly DbContextOptions<DevHobbyDbContext> options;

    public CourseRemoveTests()
    {
        options = GetDbContextOptions();
    }

    [Fact]
    public async Task DeleteCourseAsync_ShouldRemoveCourseFromDatabase()
    {
        // Arrange
        Guid courseId;

        using (var context = new DevHobbyDbContext(options))
        {
            courseId = await SeedTestCourse(context);
        }

        // Act
        using (var context = new DevHobbyDbContext(options))
        {
            var course = await context.Courses.FindAsync(courseId);
            context.Courses.Remove(course);
            await context.SaveChangesAsync();
        }

        // Assert
        using (var context = new DevHobbyDbContext(options))
        {
            var deletedCourse = await context.Courses.FindAsync(courseId);
            deletedCourse.Should().BeNull();
        }
    }
}

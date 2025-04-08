using DevHobby.CourseFlow.Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace DevHobby.CourseFlow.Persistence.IntegrationTests;

public class CourseWriteTests : TestBase
{
    private readonly DbContextOptions<DevHobbyDbContext> options;

    public CourseWriteTests()
    {
        options = GetDbContextOptions();
    }

    [Fact]
    public async Task AddCourseAsync_ShouldAddCourseToDatabase()
    {
        // Arrange
        var categoryId = Guid.Parse("{f7aac0ff-28f0-4427-be8b-41472b9b55db}");
        var newCourseId = Guid.NewGuid();

        using (var context = new DevHobbyDbContext(options))
        {
            await SeedBasicData(context);
        }

        // Act
        using (var context = new DevHobbyDbContext(options))
        {
            var newCourse = new Course
            {
                CourseId = newCourseId,
                Name = "New Test Course",
                Price = 250,
                Author = "New Author",
                CategoryId = categoryId,
                Description = "New Course Description",
                PublicationDate = DateTime.Now
            };

            context.Courses.Add(newCourse);
            await context.SaveChangesAsync();
        }

        // Assert
        using (var context = new DevHobbyDbContext(options))
        {
            var addedCourse = await context.Courses.FindAsync(newCourseId);
            addedCourse.Should().NotBeNull();
            addedCourse!.Name.Should().Be("New Test Course");
            addedCourse.Price.Should().Be(250);
            // Sprawdzamy czy pole CreatedDate zostało automatycznie uzupełnione
            addedCourse.CreatedDate.Should().NotBe(default);
            addedCourse.LastModifiedDate.Should().Be(default);
        }
    }

    [Fact]
    public async Task UpdateCourseAsync_ShouldUpdateCourseInDatabase()
    {
        // Arrange
        Guid courseId;

        using (var context = new DevHobbyDbContext(options))
        {
            courseId = await SeedTestCourse(context, "Original Course", 100);
        }

        // Pozyskujemy oryginalną datę utworzenia
        DateTime originalCreatedDate;
        using (var context = new DevHobbyDbContext(options))
        {
            var course = await context.Courses.FindAsync(courseId);
            originalCreatedDate = course.CreatedDate;
        }

        // Act - aktualizujemy kurs
        using (var context = new DevHobbyDbContext(options))
        {
            var course = await context.Courses.FindAsync(courseId);
            course.Name = "Updated Course";
            course.Price = 150;
            await context.SaveChangesAsync();
        }

        // Assert
        using (var context = new DevHobbyDbContext(options))
        {
            var updatedCourse = await context.Courses.FindAsync(courseId);
            updatedCourse.Should().NotBeNull();
            updatedCourse!.Name.Should().Be("Updated Course");
            updatedCourse.Price.Should().Be(150);

            // Sprawdzamy, czy CreatedDate się nie zmieniła
            updatedCourse.CreatedDate.Should().Be(originalCreatedDate);

            // Sprawdzamy, czy LastModifiedDate została zaktualizowana
            updatedCourse.LastModifiedDate.Should().NotBe(default);
        }
    }
}

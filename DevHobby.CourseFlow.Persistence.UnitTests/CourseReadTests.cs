using DevHobby.CourseFlow.Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace DevHobby.CourseFlow.Persistence.IntegrationTests;

public class CourseReadTests : TestBase
{
    private readonly DbContextOptions<DevHobbyDbContext> options;

    public CourseReadTests()
    {
        options = GetDbContextOptions();
    }

    [Fact]
    public async Task GetCourseByIdAsync_WithValidId_ShouldReturnCourse()
    {
        // Arrange
        Guid courseId;

        using (var context = new DevHobbyDbContext(options))
        {
            courseId = await SeedTestCourse(context, "C# Podstawy", 250);
        }

        // Act
        using (var context = new DevHobbyDbContext(options))
        {
            var course = await context.Courses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.CourseId == courseId);

            // Assert
            course.Should().NotBeNull();
            course.Name.Should().Be("C# Podstawy");
            course.Price.Should().Be(250);
            course.Category.Name.Should().Be("Test Category");
        }
    }

    [Fact]
    public async Task GetAllCoursesAsync_ShouldReturnAllCourses()
    {
        // Arrange
        using (var context = new DevHobbyDbContext(options))
        {
            await SeedTestCourse(context, "Kurs 1", 100);
            await SeedTestCourse(context, "Kurs 2", 200);
            await SeedTestCourse(context, "Kurs 3", 300);
        }

        // Act
        using (var context = new DevHobbyDbContext(options))
        {
            var courses = await context.Courses
                .Include(c => c.Category)
                .ToListAsync();

            // Assert
            courses.Count.Should().Be(3);
            courses.Should().Contain(c => c.Name == "Kurs 1");
            courses.Should().Contain(c => c.Name == "Kurs 2", "bo kurs o nazwie 'Kurs 2' powinien istnieć na liście");
            courses.Should().Contain(c => c.Name == "Kurs 3", "bo kurs o nazwie 'Kurs 3' powinien istnieć na liście");
        }
    }

    [Fact]
    public async Task GetCoursesByCategoryAsync_ShouldReturnFilteredCourses()
    {
        // Arrange
        var categoryId = Guid.Parse("{f7aac0ff-28f0-4427-be8b-41472b9b55db}");
        var differentCategoryId = Guid.NewGuid();

        using (var context = new DevHobbyDbContext(options))
        {
            await SeedBasicData(context);

            // Dodajemy drugą kategorię
            context.Categories.Add(new Category
            {
                CategoryId = differentCategoryId,
                Name = "Different Category"
            });
            await context.SaveChangesAsync();

            // Dodajemy kursy do drugiej kategorii
            await SeedTestCourse(context, "C# Kurs", 100);

            context.Courses.Add(new Course
            {
                CourseId = Guid.NewGuid(),
                Name = "JavaScript Kurs",
                Price = 150,
                Author = "JS Author",
                CategoryId = differentCategoryId,
                Description = "JS Description",
                PublicationDate = DateTime.Now
            });
            await context.SaveChangesAsync();
        }

        // Act
        using (var context = new DevHobbyDbContext(options))
        {
            var courses = await context.Courses
                .Where(c => c.CategoryId == categoryId)
                .ToListAsync();

            // Assert
            courses.Should().ContainSingle().Which.Name.Should().Be("C# Kurs");
        }
    }
}

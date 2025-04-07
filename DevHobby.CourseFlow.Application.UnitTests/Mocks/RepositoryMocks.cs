using DevHobby.CourseFlow.Application.Contracts.Persistence;
using DevHobby.CourseFlow.Domain.Entities;
using Moq;

namespace DevHobby.CourseFlow.Application.UnitTests.Mocks;

public class RepositoryMocks
{
    public static Mock<ICategoryRepository> GetCategoryRepository()
    {
        var concertGuid = Guid.Parse("{f7aac0ff-28f0-4427-be8b-41472b9b55db}");
        var musicalGuid = Guid.Parse("{d157b292-cf64-47df-815e-298c34ebc7a3}");
        var playGuid = Guid.Parse("{3141995d-9911-48b0-b651-b5ea6aadfc1d}");
        var conferenceGuid = Guid.Parse("{95057448-5345-4657-9668-c8942a28db26}");

        var categories = new List<Category>
        {
            new Category
            {
                CategoryId = concertGuid,
                Name = "C# Programming"
            },
            new Category
            {
                CategoryId = musicalGuid,
                Name = "Web Development"
            },
            new Category
            {
                CategoryId = conferenceGuid,
                Name = "Mobile Development"
            },
            new Category
            {
                CategoryId = playGuid,
                Name = "Game Development"
            }
        };

        var mockCategoryRepository = new Mock<ICategoryRepository>();
        mockCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

        mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync((Category category) =>
        {
            categories.Add(category);
            return category;
        });

        return mockCategoryRepository;
    }
}

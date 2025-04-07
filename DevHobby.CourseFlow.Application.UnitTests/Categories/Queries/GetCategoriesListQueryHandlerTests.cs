using AutoMapper;
using DevHobby.CourseFlow.Application.Contracts.Persistence;
using DevHobby.CourseFlow.Application.Features.Categories.Queries.GetCategoriesList;
using DevHobby.CourseFlow.Application.UnitTests.Mocks;
using FluentAssertions;
using Moq;

namespace DevHobby.CourseFlow.Application.UnitTests.Categories.Queries;

public class GetCategoriesListQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ICategoryRepository> _mockCategoryRepository;

    public GetCategoriesListQueryHandlerTests()
    {
        _mapper = MappingMocks.GetMapper();
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
    }

    [Fact]
    public async Task GetCategoriesListTest()
    {
        // Arrange
        var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object);

        // Act
        var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

        // Assert
        result.Should().BeOfType<List<CategoryListVm>>();
        result.Count.Should().Be(4);
    }
}

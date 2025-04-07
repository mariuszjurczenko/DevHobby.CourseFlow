using AutoMapper;
using DevHobby.CourseFlow.Application.Contracts.Persistence;
using DevHobby.CourseFlow.Application.Features.Categories.Commands.CreateCateogry;
using DevHobby.CourseFlow.Application.UnitTests.Mocks;
using FluentAssertions;
using Moq;

namespace DevHobby.CourseFlow.Application.UnitTests.Categories.Commands;

public class CreateCategoryTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ICategoryRepository> _mockCategoryRepository;

    public CreateCategoryTests()
    {
        _mapper = MappingMocks.GetMapper();
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
    }

    [Fact]
    public async Task Handle_ValidCategory_AddedToCategoriesRepo()
    {
        var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

        await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);

        var allCategories = await _mockCategoryRepository.Object.ListAllAsync();
        allCategories.Count().Should().Be(5);
    }

    [Fact]
    public async Task Handle_InvalidCategory_ValidationErrorsInResponse()
    {
        var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

        var response = await handler.Handle(new CreateCategoryCommand() { Name = "" }, CancellationToken.None);

        response.Success.Should().BeFalse();
        response.ValidationErrors.Should().NotBeEmpty();
    }
}

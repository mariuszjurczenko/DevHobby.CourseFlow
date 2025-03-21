using AutoMapper;
using DevHobby.CourseFlow.Application.Contracts.Persistence;
using DevHobby.CourseFlow.Domain.Entities;
using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Categories.Commands.CreateCateogry;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var createCategoryCommandResponse = new CreateCategoryCommandResponse();
        var validator = new CreateCategoryCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            createCategoryCommandResponse.Success = false;
            createCategoryCommandResponse.ValidationErrors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        if (createCategoryCommandResponse.Success)
        {
            var category = new Category() { Name = request.Name };  
            category = await _categoryRepository.AddAsync(category);
            createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);
        }
        return createCategoryCommandResponse;
    }
}

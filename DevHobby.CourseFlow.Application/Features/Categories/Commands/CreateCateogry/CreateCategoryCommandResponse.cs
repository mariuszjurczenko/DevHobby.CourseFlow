using DevHobby.CourseFlow.Application.Responses;

namespace DevHobby.CourseFlow.Application.Features.Categories.Commands.CreateCateogry;

public class CreateCategoryCommandResponse : BaseResponse
{
    public CreateCategoryCommandResponse() : base()
    {}

    public CreateCategoryDto Category { get; set; }
}
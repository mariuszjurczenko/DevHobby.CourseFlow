using DevHobby.CourseFlow.Application.Features.Categories.Commands.CreateCateogry;
using DevHobby.CourseFlow.Application.Features.Categories.Queries.GetCategoriesList;
using DevHobby.CourseFlow.Application.Features.Categories.Queries.GetCategoriesListWithCourses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevHobby.CourseFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all", Name = "GetAllCategories")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
    {
        var dtos = await _mediator.Send(new GetCategoriesListQuery());
        return Ok(dtos);
    }

    [HttpGet("allwithcourses", Name = "GetCategoriesWithCourses")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CategoryCourseListVm>>> GetCategoriesWithCourses(bool includePlannedCourses)
    {
        GetCategoriesListWithCoursesQuery getCategoriesListWithCoursesQuery = new GetCategoriesListWithCoursesQuery()
        {
            IncludePlannedCourses = includePlannedCourses
        };

        var dtos = await _mediator.Send(getCategoriesListWithCoursesQuery);
        return Ok(dtos);
    }

    [HttpPost(Name = "AddCategory")]
    public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        var response = await _mediator.Send(createCategoryCommand);
        return Ok(response);
    }
}

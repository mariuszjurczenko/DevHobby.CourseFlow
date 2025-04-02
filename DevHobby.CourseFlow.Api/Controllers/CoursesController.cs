using DevHobby.CourseFlow.Application.Features.Courses.Commands.CreateCourse;
using DevHobby.CourseFlow.Application.Features.Courses.Commands.DeleteCourse;
using DevHobby.CourseFlow.Application.Features.Courses.Commands.UpdateCourse;
using DevHobby.CourseFlow.Application.Features.Courses.Queries.GetCourseDetail;
using DevHobby.CourseFlow.Application.Features.Courses.Queries.GetCoursesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevHobby.CourseFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : Controller
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllCourses")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<CourseListVm>>> GetAllCourses()
    {
        var result = await _mediator.Send(new GetCoursesListQuery());
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetCourseById")]
    public async Task<ActionResult<CourseDetailVm>> GetCourseById(Guid id)
    {
        var getCourseDetailQuery = new GetCourseDetailQuery() { Id = id };
        return Ok(await _mediator.Send(getCourseDetailQuery));
    }

    [HttpPost(Name = "AddCourse")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateCourseCommand createCourseCommand)
    {
        var id = await _mediator.Send(createCourseCommand);
        return Ok(id);
    }

    [HttpPut(Name = "UpdateCourse")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateCourseCommand updateCourseCommand)
    {
        await _mediator.Send(updateCourseCommand);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteCourse")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        var deleteCourseCommand = new DeleteCourseCommand() { CourseId = id };
        await _mediator.Send(deleteCourseCommand);
        return NoContent();
    }
}

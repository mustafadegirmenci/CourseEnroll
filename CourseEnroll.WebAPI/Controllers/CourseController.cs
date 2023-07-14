using CourseEnroll.Application.Features.CourseFeatures.CreateCourse;
using CourseEnroll.Application.Features.CourseFeatures.DeleteCourse;
using CourseEnroll.Application.Features.CourseFeatures.GetAllCourse;
using CourseEnroll.Application.Features.CourseFeatures.GetCourse;
using CourseEnroll.Application.Features.CourseFeatures.UpdateCourse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnroll.Controllers;

[ApiController]
[Route("course")]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<GetCourseResponse>> GetById([FromRoute]GetCourseRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response.Course);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllCourseResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllCourseRequest(), cancellationToken);
        return Ok(response.Courses);
    }

    [HttpPost]
    public async Task<ActionResult<CreateCourseResponse>> Create(CreateCourseRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
        
    [HttpPut]
    public async Task<ActionResult<UpdateCourseRequest>> Update(UpdateCourseRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpDelete("{Id}")]
    public async Task<ActionResult<CreateCourseResponse>> Delete([FromRoute]DeleteCourseRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}

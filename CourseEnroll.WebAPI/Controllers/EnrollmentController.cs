using CourseEnroll.Application.Features.CourseFeatures.CreateCourse;
using CourseEnroll.Application.Features.CourseFeatures.DeleteCourse;
using CourseEnroll.Application.Features.CourseFeatures.GetAllCourse;
using CourseEnroll.Application.Features.CourseFeatures.GetCourse;
using CourseEnroll.Application.Features.CourseFeatures.UpdateCourse;
using CourseEnroll.Application.Features.EnrollmentFeatures.GetEnrollmentByCourseId;
using CourseEnroll.Application.Features.EnrollmentFeatures.GetEnrollmentByStudentId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnroll.Controllers;

[ApiController]
[Route("enrollment")]
public class EnrollmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public EnrollmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<GetEnrollmentByStudentIdResponse>> GetByStudentId([FromRoute]GetEnrollmentByStudentIdRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response.Enrollments);
    }

    [Route("byStudentId")]
    [HttpGet("{Id}")]
    public async Task<ActionResult<GetEnrollmentByCourseIdResponse>> GetByCourseId([FromRoute]GetEnrollmentByCourseIdRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response.Enrollments);
    }

    [Route("byCourseId")]
    [HttpPost]
    public async Task<ActionResult<CreateCourseResponse>> Create(CreateCourseRequest request,
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

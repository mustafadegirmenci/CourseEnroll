using CourseEnroll.Application.Features.StudentFeatures.CreateStudent;
using CourseEnroll.Application.Features.StudentFeatures.DeleteStudent;
using CourseEnroll.Application.Features.StudentFeatures.GetAllStudent;
using CourseEnroll.Application.Features.StudentFeatures.UpdateStudent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnroll.Controllers;

[ApiController]
[Route("student")]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllStudentResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllStudentRequest(), cancellationToken);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<CreateStudentResponse>> Create(CreateStudentRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult<CreateStudentResponse>> Update(UpdateStudentRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpDelete]
    public async Task<ActionResult<CreateStudentResponse>> Delete(DeleteStudentRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}

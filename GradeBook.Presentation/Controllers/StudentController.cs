

using GradeBook.Application.Dtos;
using GradeBook.Application.Queries.Students.GetStudentById;
using GradeBook.Application.Queries.Students.GetStudents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace GradeBook.Presentation.Controllers;

[Route("api/students")]
[ApiController]
public class StudentController : Controller
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [SwaggerOperation("Get students")]
    [ProducesResponseType(typeof(IEnumerable<StudentDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Get()
    {
        var result = await _mediator.Send(new GetStudentsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    [SwaggerOperation("Get student by Id")]
    [ProducesResponseType(typeof(StudentDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetStudentByIdQuery(id));
        return result != null ? Ok(result) : NotFound(); ;
    }
}

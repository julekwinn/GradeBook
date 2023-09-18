

using GradeBook.Application.Commands.Students.AddStudent;
using GradeBook.Application.Commands.Students.RemoveStudent;
using GradeBook.Application.Commands.Students.UpdateStudent;
using GradeBook.Application.Dtos;
using GradeBook.Application.Queries.Students.GetStudentByEmail;
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


    [HttpGet("[action]/{email}")]
    [SwaggerOperation("Get student by email")]
    [ProducesResponseType(typeof(StudentDto), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetByEmail([FromRoute] string email)
    {
        var result = await _mediator.Send(new GetStudentByEmailQuery(email));
        return result != null ? Ok(result) : NotFound(); ;
    }


    [HttpPost]
    [SwaggerOperation("Add Student")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult> Post([FromBody]AddStudentCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    [SwaggerOperation("Update Student")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Put([FromBody] UpdateStudentCommand command)
    {
        await _mediator.Send(command);
        return NoContent(); 
    }

    [HttpDelete("{id}")]
    [SwaggerOperation("Remove Student")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new RemoveStudentCommand(id));
        return NoContent();
    }
}

using GradeBook.Application.Dtos;
using MediatR;

namespace GradeBook.Application.Queries.Students.GetStudents;

public record GetStudentsQuery() : IRequest<IEnumerable<StudentDto>>
{
}

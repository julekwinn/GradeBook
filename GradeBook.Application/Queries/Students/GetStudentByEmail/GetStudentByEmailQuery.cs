
using GradeBook.Application.Dtos;
using MediatR;

namespace GradeBook.Application.Queries.Students.GetStudentByEmail;

public record GetStudentByEmailQuery(string Email) :IRequest<StudentDto>
{
}

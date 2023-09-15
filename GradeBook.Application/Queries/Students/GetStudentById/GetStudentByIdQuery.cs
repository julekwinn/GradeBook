
using GradeBook.Application.Dtos;
using MediatR;

namespace GradeBook.Application.Queries.Students.GetStudentById
{
    public record GetStudentByIdQuery(int Id) : IRequest<StudentDto>
    {
    }
}

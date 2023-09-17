

using MediatR;

namespace GradeBook.Application.Commands.Students.RemoveStudent
{
    public record RemoveStudentCommand(int Id) : IRequest
    {
    }
}



using Gradebook.Domain.Abstractions;
using GradeBook.Application.Dtos;
using MediatR;

namespace GradeBook.Application.Queries.Students.GetStudentById;

internal class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
{
    private readonly IStudentRepository _studentRepository;
    public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id, cancellationToken);

        var studentDto = new StudentDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            Age = DateTime.Now.Year - student.DateOfBirth.ToDateTime(TimeOnly.Parse("00:00")).Year,
            YearEnrolled = student.YearEnrolled,
        };
        return studentDto;
    }
}

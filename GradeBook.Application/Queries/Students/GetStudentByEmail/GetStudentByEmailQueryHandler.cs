using GradeBook.Application.Dtos;
using Gradebook.Domain.Abstractions;
using MediatR;

namespace GradeBook.Application.Queries.Students.GetStudentByEmail;

internal class GetStudentByEmailQueryHandler : IRequestHandler<GetStudentByEmailQuery, StudentDto>
{
    private readonly IStudentRepository _studentRepository;
    public GetStudentByEmailQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<StudentDto> Handle(GetStudentByEmailQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByEmailAsync(request.Email, cancellationToken);

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


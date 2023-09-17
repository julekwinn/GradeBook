using GradeBook.Application.Dtos;
using MediatR;


namespace GradeBook.Application.Commands.Students.AddStudent
{
    public class AddStudentCommand : IRequest<StudentDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int YearEnrolled { get; set; }
    }
}

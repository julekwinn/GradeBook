using GradeBook.Application.Configuration.Commands;
using GradeBook.Application.Dtos;


namespace GradeBook.Application.Commands.Students.AddStudent
{
    public class AddStudentCommand : ICommanda<StudentDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int YearEnrolled { get; set; }
    }
}

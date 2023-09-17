
using FluentValidation;
using GradeBook.Application.Commands.Students.AddStudent;

namespace GradeBook.Application.Commands.Students.UpdateStudent;

internal class UpdateStudentCommandValidation : AbstractValidator<UpdateStudentCommand>

{

    public UpdateStudentCommandValidation()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().
            WithMessage("First Name is required")
            .MaximumLength(50)
            .WithMessage("First name cannot be longer than 50 character");

        RuleFor(x => x.LastName)
            .NotEmpty().
            WithMessage("Last Name is required")
            .MaximumLength(50)
            .WithMessage("Last name cannot be longer than 50 character");

        RuleFor(x => x.Email)
            .NotEmpty().
            WithMessage("Email Name is required")
            .MaximumLength(100)
            .WithMessage("Email name cannot be longer than 100 character")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().
            WithMessage("Date of birth is required")
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now.AddYears(-18))).
            WithMessage("Student must be at least 18 years old");

        RuleFor(x => x.YearEnrolled)
            .NotEmpty().
            WithMessage("Year enrolled name is required");
    }
}

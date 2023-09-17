
using Gradebook.Domain.Abstractions;
using GradeBook.Application.Dtos;
using Gradebook.Domain.Exceptions;
using Gradebook.Domain.Entities;
using AutoMapper;
using GradeBook.Application.Configuration.Commands;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace GradeBook.Application.Commands.Students.AddStudent;

internal class AddStudentCommandHandler : ICommandaHandler<AddStudentCommand, StudentDto>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<AddStudentCommand> _validator;
    public AddStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork, IMapper mappper, IValidator<AddStudentCommand> validator)
    {
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mappper;
        _validator = validator;
    }
    public async Task<StudentDto> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult result = _validator.Validate(request);
        if (!result.IsValid)
        {
            var errorList = result.Errors.Select(s => s.ErrorMessage);
            throw new FluentValidation.ValidationException($"Invalid Command, reasons: {string.Join(",", errorList.ToArray())}");
        }


        bool isAlreadyExist = await _studentRepository.IsAlreadyExistAsync(request.Email,cancellationToken);
        if (isAlreadyExist) 
        {
            throw new StudentAlreadyExistException(request.Email);
        }

        var newStudent = new Student()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            YearEnrolled = request.YearEnrolled,
        };

        _studentRepository.Add(newStudent);
        await _unitOfWork.SaveChangesAsync();

        var studentDto = _mapper.Map<StudentDto>(newStudent);

        return studentDto;
    }
}

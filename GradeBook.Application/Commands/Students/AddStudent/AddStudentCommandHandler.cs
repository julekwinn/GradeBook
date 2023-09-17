﻿
using Gradebook.Domain.Abstractions;
using GradeBook.Application.Dtos;
using Gradebook.Domain.Exceptions;
using Gradebook.Domain.Entities;
using AutoMapper;
using GradeBook.Application.Configuration.Commands;

namespace GradeBook.Application.Commands.Students.AddStudent;

internal class AddStudentCommandHandler : ICommandaHandler<AddStudentCommand, StudentDto>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public AddStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork, IMapper mappper)
    {
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mappper;
    }
    public async Task<StudentDto> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
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

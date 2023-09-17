using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.Application.Commands.Students.UpdateStudent
{
 
    internal class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.Id, cancellationToken);
            if (student == null) 
            {
                throw new StudentNotFoundException(request.Id);
            }

            student.FirstName= request.FirstName;
            student.LastName= request.LastName;
            student.Email= request.Email;
            student.DateOfBirth= request.DateOfBirth;
            student.YearEnrolled= request.YearEnrolled;

            _studentRepository.Update(student);
            await _unitOfWork.SaveChangesAsync();




        }
    }
}

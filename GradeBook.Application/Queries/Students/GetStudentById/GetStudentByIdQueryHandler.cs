

using AutoMapper;
using Gradebook.Domain.Abstractions;
using GradeBook.Application.Dtos;
using MediatR;

namespace GradeBook.Application.Queries.Students.GetStudentById;

internal class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentByIdQueryHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id, cancellationToken);

        var studentDto = _mapper.Map<StudentDto>(student);
        return studentDto;
    }
}


using MediatR;

namespace GradeBook.Application.Configuration.Commands;

public interface ICommanda : IRequest
{
}

public interface ICommanda<out TResult> : IRequest<TResult>
{
}

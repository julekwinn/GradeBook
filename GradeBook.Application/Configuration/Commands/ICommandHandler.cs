

using MediatR;

namespace GradeBook.Application.Configuration.Commands;

public interface ICommandaHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommanda
{
}

public interface ICommandaHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommanda<TResult>
{
}


namespace Gradebook.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellation = default);
    }
}

using Gradebook.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        public Task SaveChangesAsync(CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
    }
}

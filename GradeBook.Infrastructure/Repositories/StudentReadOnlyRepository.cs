using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using GradeBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GradeBook.Infrastructure.Repositories
{
    internal class StudentReadOnlyRepository : IStudentReadOnlyRepository
    {
        private readonly GradeBookDbContext _dbContext;
        public StudentReadOnlyRepository(GradeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellation = default)
        {
            return await _dbContext.Students.AsNoTracking().ToListAsync(cancellation);
        }
    }
}

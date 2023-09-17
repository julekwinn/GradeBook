using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;
using GradeBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GradeBook.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly GradeBookDbContext _dbContext;
        public StudentRepository(GradeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellation = default)
        {
            return await _dbContext.Students.ToListAsync(cancellation);
        }

        public async Task<Student> GetByIdAsync(int id, CancellationToken cancellation = default)
        {
            return await _dbContext.Students.SingleOrDefaultAsync(x => x.Id == id,cancellation);
        }
        public async Task<Student> GetByEmailAsync(string email, CancellationToken cancellation = default)
        {
            return await _dbContext.Students.SingleOrDefaultAsync(x => x.Email == email, cancellation);
        }
        public Task<bool> IsAlreadyExistAsync(string email, CancellationToken cancellation = default)
        {;
            return _dbContext.Students.AnyAsync(x => x.Email == email, cancellation);
        }
        public void Add(Student student)
        {
            _dbContext.Students.Add(student);
        }
        public void Update(Student student)
        {
            _dbContext.Students.Update(student);
        }
        public void Delete(Student student)
        {
            _dbContext.Students.Remove(student);
        }
    }
}

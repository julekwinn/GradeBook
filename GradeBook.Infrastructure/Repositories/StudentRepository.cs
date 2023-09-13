﻿using Gradebook.Domain.Abstractions;
using Gradebook.Domain.Entities;

namespace GradeBook.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
        public Task<Student> GetByIdAsync(int id, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
        public Task<Student> GetByEmailAsync(string email, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
        public Task<bool> IsAlreadyExistAsync(string email, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
        public void Add(Student student)
        {
            throw new NotImplementedException();
        }
        public void Update(Student student)
        {
            throw new NotImplementedException();
        }
        public void Delete(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
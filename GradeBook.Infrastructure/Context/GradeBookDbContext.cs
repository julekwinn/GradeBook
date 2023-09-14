using Gradebook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GradeBook.Infrastructure.Context
{
    internal class GradeBookDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public GradeBookDbContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("gradebook");
        }


    }
}

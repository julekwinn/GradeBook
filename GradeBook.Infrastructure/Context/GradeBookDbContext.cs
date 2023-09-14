using Gradebook.Domain.Entities;
using GradeBook.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace GradeBook.Infrastructure.Context
{
    public class GradeBookDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public GradeBookDbContext(DbContextOptions options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("gradebook");

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }


    }
}

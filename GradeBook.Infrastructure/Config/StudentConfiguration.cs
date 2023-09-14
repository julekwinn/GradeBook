
using Gradebook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;

namespace GradeBook.Infrastructure.Config
{
    public class StudentConfiguration: BaseEntityConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.Property(s => s.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(s => s.LastName)
                .HasMaxLength(50)
                .IsRequired();



            builder.HasIndex(s => s.Email)
                .IsUnique();
            builder.Property(s => s.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s=>s.DateOfBirth)
                .HasConversion<DateOnlyConverter>()
                .HasColumnName("date")
                .IsRequired();


            builder.Property(s => s.YearEnrolled)
                .IsRequired();



            base.Configure(builder);
        }
    }
}

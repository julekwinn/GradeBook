using Gradebook.Domain.Abstractions;
using GradeBook.Infrastructure.Context;
using GradeBook.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace GradeBook.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddDbContext<GradeBookDbContext>(ctx => ctx.UseSqlServer(configuration.GetConnectionString("GradebookCS")));
            return services;
        }
    }
}

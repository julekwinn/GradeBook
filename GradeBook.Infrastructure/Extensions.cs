using GradeBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace GradeBook.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GradeBookDbContext>(ctx => ctx.UseSqlServer(configuration.GetConnectionString("GradebookCS")));
            return services;
        }
    }
}

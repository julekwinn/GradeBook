
using Gradebook.Domain.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GradeBook.Presentation;

public static class Extensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(swagger => { swagger.EnableAnnotations(); });

        services.AddControllers();
        return services;
    }
}

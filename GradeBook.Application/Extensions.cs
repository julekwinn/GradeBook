
using FluentValidation;
using GradeBook.Application.Commands.Students.AddStudent;
using GradeBook.Application.Commands.Students.UpdateStudent;
using GradeBook.Application.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GradeBook.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(executingAssembly);

        services.AddScoped<IValidator<AddStudentCommand>, AddStudentCommandValidation>();
        services.AddScoped<IValidator<UpdateStudentCommand>, UpdateStudentCommandValidation>();

        services.AddTransient<ExceptionHandlingMiddleware>();
        return services;
    }

    public static IApplicationBuilder UseApplication(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        return app;
    }
}

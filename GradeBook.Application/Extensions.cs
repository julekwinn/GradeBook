
using FluentValidation;
using GradeBook.Application.Commands.Students.AddStudent;
using GradeBook.Application.Commands.Students.UpdateStudent;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GradeBook.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(executingAssembly);
        services.AddAutoMapper(executingAssembly);

        services.AddScoped<IValidator<AddStudentCommand>, AddStudentCommandValidation>();
        services.AddScoped<IValidator<UpdateStudentCommand>, UpdateStudentCommandValidation>();
        return services;
    }
}
